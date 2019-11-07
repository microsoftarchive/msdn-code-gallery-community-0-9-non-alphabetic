using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net;

namespace TBAuction
{
    class OrderPageHandleOld
    {
        AuctionLog auctionLog;
        AuctionOperations auctionOperations;
        CheckCodeForm checkCodeForm;

        public OrderPageHandleOld(AuctionLog auctionLog)
        {
            this.auctionLog = auctionLog;
            auctionOperations = new AuctionOperations(auctionLog);
            checkCodeForm = new CheckCodeForm();
        }

        //清除所有信息变量
        public void Init()
        {
            if (inputControls != null)
            { inputControls.Clear(); }
            else
            { inputControls = new ArrayList(); }

            addressParams = string.Empty;
            addressInformation.Id = string.Empty;
            addressInformation.Address = string.Empty;
            addressInformation.Postcode = string.Empty;
            addressInformation.Addressee = string.Empty;
            addressInformation.Phone = string.Empty;
            addressInformation.Mobile = string.Empty;
            addressInformation.AreaCode = string.Empty;           

            isCheckCode = false;
            encryptString = string.Empty;

            postage.Selected = string.Empty;
            postage.Fare = string.Empty;
            if (postage.Transports != null)
            {
                postage.Transports.Clear();
            }
            else
            {
                postage.Transports = new ArrayList();
            }

            promotion.Id = string.Empty;
            promotion.Price = string.Empty;
            promotion.AverageSum = string.Empty;
            promotion.Bundle = string.Empty;
            if (promotion.Bundles != null)
            { promotion.Bundles.Clear(); }
            else
            { promotion.Bundles = new ArrayList(); }

            shopPromotion.Id = string.Empty;
            shopPromotion.Bundle = string.Empty;
            if (shopPromotion.Bundles != null)
            { shopPromotion.Bundles.Clear(); }
            else
            { shopPromotion.Bundles = new ArrayList(); }

            actualFee = 0;
           
        }

        #region 该段代码用于读取订单表单信息

        //输入控件信息类
        private struct InputControl
        {
            public string Control { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private struct AddressInformation
        {
            public string Id { get; set; }
            public string Address { get; set; }
            public string Postcode { get; set; }
            public string Addressee { get; set; }
            public string Phone { get; set; }
            public string Mobile { get; set; }
            public string AreaCode { get; set; }  
        }

        ArrayList inputControls;
        AddressInformation addressInformation = new AddressInformation();
        string addressParams;
        bool isCheckCode;
        string encryptString;

        //获取表单控件列表
        private void GetOrderFormContent(string orderPage)
        {
            string frmContent, inputContent;
            Match tempMatch;
            bool addressInfoGeted = false;

            MatchCollection matches = Regex.Matches(orderPage, "<form\\s+name\\s*=\\s*\"mainform\"\\s+.*?>.*?<\\s*/\\s*form\\s*>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (matches.Count > 0)
            {
                auctionLog.Log("通知：发现了订单页面中的表单");
                frmContent = matches[0].ToString();
                matches = Regex.Matches(frmContent, "<\\s*(?<control>input|select|textarea).*?>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (matches.Count > 0)
                {
                    auctionLog.Log("通知：发现了订单页面表单中的input控件");
                    foreach (Match match in matches)
                    {
                        InputControl inputControl = new InputControl();

                        inputContent = match.ToString();
                        tempMatch = Regex.Match(inputContent, "name\\s*=\\s*[\"\'](?<name>.*?)[\"\']", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            inputControl.Control = match.Groups["control"].ToString();

                            inputControl.Name = tempMatch.Groups["name"].ToString();
                            
                            //读取收货地址信息
                            if (!addressInfoGeted && inputControl.Control.ToLower() == "input" && inputControl.Name.ToLower() == "address")
                            {
                                tempMatch = Regex.Match(inputContent, "ah:params\\s*=\\s*[\"\'](?<params>.*?)[\"\']", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                addressParams = tempMatch.Groups["params"].ToString();

                                tempMatch = Regex.Match(addressParams, "id\\s*=\\s*(?<id>\\d+)\\s*\\^\\^", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                addressInformation.Id = tempMatch.Groups["id"].ToString();

                                tempMatch = Regex.Match(addressParams, "address\\s*=\\s*(?<address>.*?)\\s*\\^\\^", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                addressInformation.Address = tempMatch.Groups["address"].ToString();

                                tempMatch = Regex.Match(addressParams, "postCode\\s*=\\s*(?<postCode>\\d+)\\s*\\^\\^", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                addressInformation.Postcode = tempMatch.Groups["postCode"].ToString();

                                tempMatch = Regex.Match(addressParams, "addressee\\s*=\\s*(?<addressee>.*?)\\s*\\^\\^", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                addressInformation.Addressee = tempMatch.Groups["addressee"].ToString();

                                tempMatch = Regex.Match(addressParams, "phone\\s*=\\s*(?<phone>.*?)\\s*\\^\\^", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                addressInformation.Phone = tempMatch.Groups["phone"].ToString();

                                tempMatch = Regex.Match(addressParams, "mobile\\s*=\\s*(?<mobile>\\d+)\\s*\\^\\^", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                addressInformation.Mobile = tempMatch.Groups["mobile"].ToString();

                                tempMatch = Regex.Match(addressParams, "areaCode\\s*=\\s*(?<areaCode>\\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                addressInformation.AreaCode = tempMatch.Groups["areaCode"].ToString();

                                addressInfoGeted = true;
                            }

                            tempMatch = Regex.Match(inputContent, "value\\s*=\\s*[\"\'](?<value>.*?)[\"\']", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            if (tempMatch.Success)
                            {
                                inputControl.Value = tempMatch.Groups["value"].ToString();
                            }

                            tempMatch = Regex.Match(inputContent, "type\\s*=\\s*[\"\'](?<type>.*?)[\"\']", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            if (tempMatch.Success)
                            {
                                inputControl.Type = tempMatch.Groups["type"].ToString();
                            }

                            //读取验证码信息
                            if (inputControl.Name.Trim().ToLower() == "ischeckcode" && inputControl.Value.Trim().ToLower() == "true")
                            {
                                isCheckCode = true;
                            }

                            if (inputControl.Name.Trim().ToLower() == "encryptstring")
                            {
                                encryptString = inputControl.Value; 
                            }

                            inputControls.Add(inputControl);
                        }
                    }
                }
            }
        }
        #endregion

        #region 该段代码用于读取订单页面信息

        //订单信息类，可能并不需要读取该项信息，暂时保留该类的定义
        private struct Order
        {
            public string ItemId { get; set; }
            public string SkuId { get; set; }
            public string Price { get; set; }
            public string Amount { get; set; }
            public string IsBundleItem { get; set; }
            public string ShopId1 { get; set; }
            public string ShopId2 { get; set; }
            public string SellerId { get; set; }
            public string BuyerId { get; set; }
            public string DivisionCode1 { get; set; }
            public string DivisionCode2 { get; set; }
            public string CodRate { get; set; }
            public string IsBSeller { get; set; }
            public string PointRate { get; set; }
            public string Exchange { get; set; }
        }

        //促销信息类
        private struct PromotionBundle
        {
            public string Id { get; set; }
            public string Discout { get; set; }
            public string FreeDelivery { get; set; }
            public string Point { get; set; }
        }
        private struct Promotion
        {
            public string Id { get; set; }
            public string Price { get; set; }
            public string AverageSum { get; set; }
            public string Bundle { get; set; }
            public ArrayList Bundles { get; set; }
        }

        private struct ShopPromotionBundle
        {
            public string Id { get; set; }
            public string Discout { get; set; }
            public string FreeDelivery { get; set; }
            public string Point { get; set; }
            public string Gift { get; set; }
        }
        private struct ShopPromotion
        {
            public string Id { get; set; }
            public string Bundle { get; set; }
            public ArrayList Bundles { get; set; }
        }

        //运送方式信息类
        private struct Postage
        {
            public string Selected { get; set; }
            public string Fare { get; set; }
            public ArrayList Transports { get; set; } 
        }

        private struct Transport
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Sum { get; set; }
            public string Value  { get; set; }          
        }

        //信息变量定义       
        Postage postage = new Postage();
        Promotion promotion = new Promotion();
        ShopPromotion shopPromotion = new ShopPromotion();       
        

        //获取网页信息域
        private string GetOrderInformationDomain(string orderPage)
        {
            Match contentMatch = Regex.Match(orderPage, "promoData(?<content>.*?)TB.Promotion.init", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (contentMatch.Success)
            {
                auctionLog.Log("通知：发现了订单页面中的信息域");
                return contentMatch.Groups["content"].ToString();
            }
            auctionLog.Log("警告：未发现订单页面中的信息域");
            return String.Empty;
        }

        //获取运费信息
        private void GetOrderTransports(string orderInformationDomain)
        {  
            if (String.IsNullOrEmpty(orderInformationDomain))
            {
                auctionLog.Log("警告：未发现订单页面中的信息域");
                return; 
            }           

            Match postagesMatch = Regex.Match(orderInformationDomain, "postages.*?\\:\\s*\\{(?<postages>.*?)\"\\s*isBSeller", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (postagesMatch.Success)
            {
                auctionLog.Log("通知：发现了订单页面中的postages信息域");
                string postagesString = postagesMatch.Groups["postages"].ToString();

                Match selectedMatch = Regex.Match(postagesString, "selected\\s*\"\\s*:\\s*\"(?<selected>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (selectedMatch.Success)
                {
                    postage.Selected = selectedMatch.Groups["selected"].ToString(); 
                }

                Match fareMatch = Regex.Match(postagesString, "fare\\s*\"\\s*:\\s*\"(?<fare>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (fareMatch.Success)
                {
                    postage.Fare = fareMatch.Groups["fare"].ToString();
                }

                Match listMatch = Regex.Match(postagesString, "list\\s*\"\\s*:\\s*\\{(?<list>.*?)_cache", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (listMatch.Success)
                {
                    string listString = listMatch.Groups["list"].ToString();
                    MatchCollection postageMatches = Regex.Matches(listString, "\"\\s*(?<id>\\d+)\\s*\"\\s*:\\s*\\{(?<postage>.*?)\\}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    foreach (Match match in postageMatches)
                    {
                        Transport transport = new Transport();
                        transport.Id = match.Groups["id"].ToString();
                        string postageString = match.Groups["postage"].ToString();

                        Match titleMatch = Regex.Match(postageString, "title\\s*\"\\s*:\\s*\"(?<title>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (titleMatch.Success)
                        {
                            transport.Title = titleMatch.Groups["title"].ToString();
                        }

                        Match sumMatch = Regex.Match(postageString, "sum\\s*\"\\s*:\\s*\"(?<sum>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (sumMatch.Success)
                        {
                            transport.Sum = sumMatch.Groups["sum"].ToString();
                        }

                        Match valueMatch = Regex.Match(postageString, "value\\s*\"\\s*:\\s*\"(?<value>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (valueMatch.Success)
                        {
                            transport.Value = valueMatch.Groups["value"].ToString();
                        }

                        postage.Transports.Add(transport);
                    }
                }                
            }        

        }

        //获取促销信息
        private void GetOrderPromotion(string orderInformationDomain)
        {
            if (String.IsNullOrEmpty(orderInformationDomain))
            {
                auctionLog.Log("警告：未发现订单页面中的信息域");
                return; 
            }   

            //获取不同的检索号
            string promotionId = string.Empty, shopPromotionId = string.Empty;

            MatchCollection tempMatches;
            string tempStr;

            Match tempMatch = Regex.Match(orderInformationDomain, "relation.*?cross_id\\s*\"\\s*:\\s*\\[\\s*\"(?<shopPromotionId>.*?)\"\\s*", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (tempMatch.Success)
            {
                shopPromotionId = tempMatch.Groups["shopPromotionId"].ToString();                
                tempMatch = Regex.Match(orderInformationDomain, shopPromotionId + "\\s*\"\\s*:\\s*\\[\\s*\"(?<promotionId>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (tempMatch.Success)
                {
                    promotionId = tempMatch.Groups["promotionId"].ToString();
                    promotion.Id = promotionId;
                }
            }

            tempMatch = Regex.Match(orderInformationDomain, "orders(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (tempMatch.Success)
            {
                orderInformationDomain = tempMatch.Groups[0].ToString();
            }

            //获取促销信息
            if (!String.IsNullOrEmpty(promotionId))
            {
                tempMatch = Regex.Match(orderInformationDomain, "\"\\s*" + promotionId + "\\s*\"\\s*:\\s*\\{" + "(?<promotionInformationDomain>.*?)orderData", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (tempMatch.Success)
                {
                    string promotionInfomationDomain = tempMatch.Groups["promotionInformationDomain"].ToString();
                    tempMatch = Regex.Match(promotionInfomationDomain, "itemId(?<betweenContent>.*?)bundles", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    if (tempMatch.Success)
                    {
                        tempStr = tempMatch.Groups["betweenContent"].ToString();

                        //读取价格信息
                        tempMatch = Regex.Match(tempStr, "price\\s*\"\\s*:\\s*\"(?<price>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            auctionLog.Log("通知：发现了价格信息");
                            promotion.Price = tempMatch.Groups["price"].ToString();
                        }

                        tempMatch = Regex.Match(tempStr, "bundle\\s*\"\\s*:\\s*\"(?<bundle>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            //获取促销绑定信息
                            auctionLog.Log("通知：发现了促销绑定信息");                            
                            promotion.Bundle = tempMatch.Groups["bundle"].ToString();
                            tempMatch = Regex.Match(tempStr, "averageSum\\s*\"\\s*:\\s*\"(?<averageSum>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            if (tempMatch.Success)
                            {
                                promotion.AverageSum = tempMatch.Groups["averageSum"].ToString();
                            }

                            tempMatch = Regex.Match(promotionInfomationDomain, "bundles\\s*\"\\s*:\\s*\\{(?<bundlesString>(\\s*\".*?\"\\s*:\\s*\\{.*?\\})*\\s*).*?\\}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            if (tempMatch.Success)
                            {
                                auctionLog.Log("通知：发现了促销信息列表");
                                string bundleString = tempMatch.Groups["bundlesString"].ToString();
                                tempMatches = Regex.Matches(bundleString, "\"(?<bundleId>.*?)\"\\s*:\\s*\\{(?<bundleContent>.*?)\\}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                if (tempMatches.Count > 0)
                                {
                                    auctionLog.Log("通知：发现了单个促销信息");
                                    foreach (Match match in tempMatches)
                                    {
                                        PromotionBundle pb = new PromotionBundle();
                                        pb.Id = match.Groups["bundleId"].ToString();
                                        string bundleContent = match.Groups["bundleContent"].ToString();

                                        tempMatch = Regex.Match(bundleContent, "discount\\s*\"\\s*:\\s*\"(?<discount>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                        pb.Discout = tempMatch.Groups["discount"].ToString();

                                        tempMatch = Regex.Match(bundleContent, "freedelivery\\s*\"\\s*:\\s*(?<freedelivery>true|false)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                        pb.FreeDelivery = tempMatch.Groups["freedelivery"].ToString();

                                        tempMatch = Regex.Match(bundleContent, "point\\s*\"\\s*:\\s*\"(?<point>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                        pb.Point = tempMatch.Groups["point"].ToString();

                                        promotion.Bundles.Add(pb);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }

        //获取店铺促销信息
        private void GetOrderShopPromotion(string orderInformationDomain)
        {
            if (String.IsNullOrEmpty(orderInformationDomain))
            {
                auctionLog.Log("警告：未发现订单页面中的信息域");
                return; 
            } 
            
            //获取不同的检索号
            string promotionId = string.Empty, shopPromotionId = string.Empty;

            MatchCollection tempMatches;
            string tempStr;

            Match tempMatch = Regex.Match(orderInformationDomain, "relation.*?cross_id\\s*\"\\s*:\\s*\\[\\s*\"(?<shopPromotionId>.*?)\"\\s*", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (tempMatch.Success)
            {
                shopPromotionId = tempMatch.Groups["shopPromotionId"].ToString();
                shopPromotion.Id = shopPromotionId;
            }

            tempMatch = Regex.Match(orderInformationDomain, "orders.*", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (tempMatch.Success)
            {
                orderInformationDomain = tempMatch.Groups[0].ToString();
            }            

            //获取店铺促销信息（这里其实和获取普通促销信息差不多，但出于淘宝将来升级的考虑，暂时都列在这里，分开来写）
            if (!String.IsNullOrEmpty(shopPromotionId))
            {
                tempMatch = Regex.Match(orderInformationDomain, ",\\s*\"\\s*" + shopPromotionId + "(?<shopPromotionInformationDomain>.*?)orderData", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (tempMatch.Success)
                {
                    string shopPromotionInfomationDomain = tempMatch.Groups["shopPromotionInformationDomain"].ToString();
                    tempMatch = Regex.Match(shopPromotionInfomationDomain, "buyerId(?<betweenContent>.*?)bundles", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    if (tempMatch.Success)
                    {
                        tempStr = tempMatch.Groups["betweenContent"].ToString();
                        tempMatch = Regex.Match(tempStr, "bundle\\s*\"\\s*:\\s*\"(?<bundle>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            //获取促销绑定信息
                            auctionLog.Log("通知：发现了店铺促销绑定信息");
                            shopPromotion.Bundle = tempMatch.Groups["bundle"].ToString();

                            tempMatch = Regex.Match(shopPromotionInfomationDomain, "bundles\\s*\"\\s*:\\s*\\{(?<shopBundlesString>(\\s*\".*?\"\\s*:\\s*\\{.*?\\})*\\s*).*?\\}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            if (tempMatch.Success)
                            {
                                auctionLog.Log("通知：发现了店铺促销列表");
                                string bundleString = tempMatch.Groups["shopBundlesString"].ToString();
                                tempMatches = Regex.Matches(bundleString, "\"(?<bundleId>.*?)\"\\s*:\\s*\\{(?<bundleContent>.*?)\\}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                if (tempMatches.Count > 0)
                                {
                                    auctionLog.Log("通知：发现了单个店铺促销信息");
                                    foreach (Match match in tempMatches)
                                    {
                                        ShopPromotionBundle pb = new ShopPromotionBundle();
                                        pb.Id = match.Groups["bundleId"].ToString();
                                        string bundleContent = match.Groups["bundleContent"].ToString();

                                        tempMatch = Regex.Match(bundleContent, "discount\\s*\"\\s*:\\s*\"(?<discount>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                        pb.Discout = tempMatch.Groups["discount"].ToString();

                                        tempMatch = Regex.Match(bundleContent, "freedelivery\\s*\"\\s*:\\s*(?<freedelivery>true|false)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                        pb.FreeDelivery = tempMatch.Groups["freedelivery"].ToString();

                                        tempMatch = Regex.Match(bundleContent, "point\\s*\"\\s*:\\s*\"(?<point>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                        pb.Point = tempMatch.Groups["point"].ToString();

                                        tempMatch = Regex.Match(bundleContent, "gift\\s*\"\\s*:\\s*\"(?<gift>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                        pb.Gift = tempMatch.Groups["gift"].ToString();

                                        shopPromotion.Bundles.Add(pb);
                                    }
                                }
                            }
                        }
                    }
                }
            }  
                     
        }

        #endregion

        #region 该段代码用于生成post数据

        int actualFee = 0;

        //获取运输方式Id，如果传入string.Empty，选择默认的运输方式；否则，查找特定的运输方式并返回Id，如果没找到返回string.Empty
        private string GetSelectedTransport(string title)
        {
            foreach (Transport transport in postage.Transports)
            {
                if (!string.IsNullOrEmpty(title) && transport.Title.Contains(title))
                {
                    actualFee += int.Parse(transport.Sum);
                    auctionLog.Log("通知：发现了指定的运输方式");                    
                    return transport.Id;
                }                
            }
            auctionLog.Log("警告：未能发现指定的运输方式");
            return GetBestTransport();
        }

        private string GetBestTransport()
        {
            int minSum = int.Parse(((Transport)postage.Transports[0]).Sum);
            string id = ((Transport)postage.Transports[0]).Id;
            
            foreach (Transport transport in postage.Transports)
            {
                if (int.Parse(transport.Sum)< minSum)
                {
                    minSum = int.Parse(transport.Sum);
                    id = transport.Id;
                }
            }
            actualFee += minSum;
            auctionLog.Log("通知：选择了最优的运输方式");            
            return id; 
        }

        //获取促销信息的post字符串，如果isMax为true，则扫描筛选最佳的优惠方式，如果没有促销信息，返回string.Empty
        private string GetPromotionString(bool isMax)
        {
            if (promotion.Bundles.Count < 1)
            {
                auctionLog.Log("通知：不存在促销信息列表");
                return string.Empty;
            }

            if (isMax)
            {
                int maxDiscount = int.Parse(((PromotionBundle)promotion.Bundles[0]).Discout);
                string maxId = promotion.Bundle;
                foreach (PromotionBundle pb in promotion.Bundles)
                {
                    if (int.Parse(pb.Discout) > maxDiscount)
                    {
                        maxDiscount = int.Parse(pb.Discout);
                        maxId = pb.Id;
                    }
                }
                actualFee -= maxDiscount;
                auctionLog.Log("通知：发现了最优的促销选项");
                return "bundleList_" + promotion.Id + "=" + maxId;
            }
            else
            {
                int defaultDiscount = int.Parse(((PromotionBundle)promotion.Bundles[0]).Discout);
                foreach (PromotionBundle pb in promotion.Bundles)
                {
                    if (pb.Id.Trim().ToLower() == promotion.Bundle.Trim().ToLower())
                    {
                        defaultDiscount = int.Parse(pb.Discout);
                        break;
                    }
                }
                actualFee -= defaultDiscount;
                auctionLog.Log("通知：选择了默认的促销选项");
                return "bundleList_" + promotion.Id + "=" + promotion.Bundle;
            }
        }

        //获取店铺促销信息的post字符串，其实与普通促销信息差不多，出于淘宝升级的考虑单列
        private string GetShopPromotionString(bool isMax)
        {
            if (shopPromotion.Bundles.Count < 1)
            {
                auctionLog.Log("通知：不存在店铺促销信息列表");
                return string.Empty;
            }

            if (isMax)
            {
                int maxDiscount = int.Parse(((ShopPromotionBundle)shopPromotion.Bundles[0]).Discout);
                string maxId = shopPromotion.Bundle;
                foreach (ShopPromotionBundle spb in shopPromotion.Bundles)
                {
                    if (int.Parse(spb.Discout) > maxDiscount)
                    {
                        maxDiscount = int.Parse(spb.Discout);
                        maxId = spb.Id;
                    }
                }
                actualFee -= maxDiscount;
                auctionLog.Log("通知：选择了最优的店铺促销信息选项");
                return "bundleList_" + shopPromotion.Id + "=" + maxId;
            }
            else
            {
                int defaultDiscount = int.Parse(((ShopPromotionBundle)shopPromotion.Bundles[0]).Discout);
                foreach (ShopPromotionBundle spb in shopPromotion.Bundles)
                {
                    if (spb.Id.Trim().ToLower() == shopPromotion.Bundle.Trim().ToLower())
                    {
                        defaultDiscount = int.Parse(spb.Discout);
                        break;
                    }
                }
                actualFee -= defaultDiscount;
                
                auctionLog.Log("通知：选择了默认的店铺促销信息选项");
                return "bundleList_" + shopPromotion.Id + "=" + shopPromotion.Bundle;
            }
        }

        //这里需要添加问题答案的部分！！！！！！！！！！！！
        public string GetOrderPostData(string orderPage,bool modifyQuantity, int quantity, bool modifyTransport, string transport, bool modifyMemo, string memo, bool modifyPromotion, bool modifyShopPromotion, bool modifyAnnoy, bool applyPriceBorder, int priceBorder, out bool lessPriceBorder, CookieContainer cc, string questionAnswer)
        {
            lessPriceBorder = true;

            if (string.IsNullOrEmpty(orderPage))
            {
                auctionLog.Log("警告：传递的订单页面源代码为空");
                return string.Empty; 
            }

            GetOrderFormContent(orderPage);

            string orderInformationDomain = GetOrderInformationDomain(orderPage);
            if (string.IsNullOrEmpty(orderInformationDomain))
            { return string.Empty; }
            
            GetOrderTransports(orderInformationDomain);
            GetOrderPromotion(orderInformationDomain);
            GetOrderShopPromotion(orderInformationDomain);

            if (inputControls.Count < 1)
            {
                auctionLog.Log("警告：未发现订单页面中的input控件");
                return string.Empty;
            }

            string postData = String.Empty;
            bool transportArranged = false, addressArranged = false, codArranged = false;
            string selectedTansport = string.Empty, bestTransport = string.Empty;

            if (string.IsNullOrEmpty(promotion.Price))
            {
                auctionLog.Log("警告：未从促销选项中获得价格信息，尝试从整个订单表单数据域中获取");
                Match priceMatch = Regex.Match(orderInformationDomain,"price\\s*\"\\s*:\\s*\"(?<price>\\d+)\\s*\"",RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (priceMatch.Success)
                {
                    actualFee = int.Parse(priceMatch.Groups["price"].ToString());
                }
                else
                {
                    auctionLog.Log("警告：未发现任何价格信息，价格边界条件失效");
                }
            }
            else
            { actualFee = int.Parse(promotion.Price); }

            //获取运输方式信息，避免重复计算运费使用
            if (postage.Transports.Count > 0)
            {
                if (modifyTransport && !string.IsNullOrEmpty(transport))
                {
                    selectedTansport = GetSelectedTransport(transport);
                }
                else
                {
                    bestTransport = GetBestTransport();
                }
            }

            //生成post数据
            foreach (InputControl inputControl in inputControls)
            {
                if (inputControl.Control.ToLower() == "input")
                {
                    if (inputControl.Type.ToLower() == "text")
                    {
                        //修改购买数量
                        if (inputControl.Name.ToLower() == "_fm.g._0.q")
                        {
                            if (modifyQuantity)
                            {
                                postData += inputControl.Name + "=" + quantity.ToString() + "&";
                            }
                            else
                            {
                                postData += inputControl.Name + "=" + inputControl.Value + "&";
                            }
                            continue;
                        }
                        
                        //填写其他地址邮政编码
                        if (inputControl.Name.ToLower() == "_fm.g._0.p")
                        {
                            postData += inputControl.Name + "=" + addressInformation.Postcode + "&";
                            continue;
                        }

                        //填写其他地址的收货人
                        if (inputControl.Name.ToLower() == "_fm.g._0.de")
                        {
                            postData += inputControl.Name + "=" + addressInformation.Addressee + "&";
                            continue;
                        }

                        //填写其他地址的手机
                        if (inputControl.Name.ToLower() == "_fm.g._0.deli")
                        {
                            postData += inputControl.Name + "=" + addressInformation.Mobile + "&";
                            continue;
                        }
                        
                        //填写验证码，这里需要添加验证码识别的部分！！！！！！！！！！！！！！！！！！！！
                        if (inputControl.Name.ToLower() == "_fm.g._0.c")
                        {
                            if (isCheckCode)
                            {
                                auctionLog.Log("通知：可能需要输入验证码");
                                DateTime dt1 = new DateTime(1970, 1, 1);
                                DateTime dt2 = DateTime.Now;
                                TimeSpan ts = new TimeSpan(dt2.Ticks - dt1.Ticks);

                                CookieCollection ccReturned;
                                Bitmap image = new Bitmap(auctionOperations.GetCheckCodeImageStream("http://checkcode.taobao.com/auction/checkcode?sessionID=" + encryptString + "&t=" + (ts.Ticks/10000).ToString(),cc,out ccReturned));
                                cc.Add(ccReturned);
                                
                                checkCodeForm.checkCodePic.Image = image;
                                checkCodeForm.ShowDialog();
                                postData += inputControl.Name + "=" + checkCodeForm.txtCheckCode.Text.Trim() + "&";
                            }
                            else
                            {
                                postData += inputControl.Name + "=" + inputControl.Value + "&";
                            }                            
                            continue;
                        }

                        //填写问题答案
                        if (inputControl.Name.ToLower() == "_fm.g._0.s" && !string.IsNullOrEmpty(questionAnswer))
                        {
                            postData += inputControl.Name + "=" + questionAnswer + "&";
                            continue;
                        }

                        postData += inputControl.Name + "=" + inputControl.Value + "&";
                        continue;
                        
                    }
                    
                    if (inputControl.Type.ToLower() == "radio")
                    {
                        //默认选择第一个收货地址
                        if (inputControl.Name.ToLower() == "address" && !addressArranged)
                        {
                            postData += inputControl.Name + "=" + inputControl.Value + "&";
                            addressArranged = true;
                            continue;
                        }                        
                        
                        //修改运输方式
                        if (inputControl.Name.ToLower() == "_shipping_option" && !transportArranged && postage.Transports.Count > 0)
                        {
                            if (modifyTransport && !string.IsNullOrEmpty(transport))
                            {                                
                                postData += inputControl.Name + "=" + selectedTansport + "&";
                            }
                            else
                            {                                
                                postData += inputControl.Name + "=" + bestTransport + "&";
                            }
                            transportArranged = true;
                            continue;
                        }

                        //修改包含货到付款的运输方式
                        if (inputControl.Name.ToLower() == "consignment" && !codArranged)
                        {
                            postData += inputControl.Name + "=" + inputControl.Value + "&";
                            codArranged = true;
                            continue;
                        }
                        continue;
                    }

                    if (inputControl.Type.ToLower() == "hidden")
                    {
                        //修改运输方式
                        if (inputControl.Name.ToLower() == "_fm.g._0.sh")
                        {
                            if (postage.Transports.Count > 0)
                            {
                                if (modifyTransport && !string.IsNullOrEmpty(transport))
                                {
                                    postData += inputControl.Name + "=" + selectedTansport + "&";
                                }
                                else
                                {
                                    postData += inputControl.Name + "=" + bestTransport + "&";
                                }
                            }
                            else
                            {
                                postData += inputControl.Name + "=" + inputControl.Value + "&";
                            }
                            continue;
                        }
                      
                        //修改购买数量
                        if (inputControl.Name.ToLower() == "quantity")
                        {
                            if (modifyQuantity)
                            {
                                postData += inputControl.Name + "=" + quantity.ToString() + "&";
                            }
                            else
                            {
                                postData += inputControl.Name + "=" + inputControl.Value + "&";
                            }
                            continue;
                        }
                        
                        //填写地区码
                        if (inputControl.Name.ToLower() == "_fm.g._0.di")
                        {
                            postData += inputControl.Name + "=" + addressInformation.AreaCode + "&";
                            continue;
                        }
                        
                        postData += inputControl.Name + "=" + inputControl.Value + "&";
                        continue;
                    }                    

                    //修改是否匿名
                    if (inputControl.Type.ToLower().Trim() == "checkbox" && inputControl.Name.ToLower().Contains("anony"))
                    {
                        //修改留言
                        if (modifyMemo)
                        {
                            postData += "_fm.g._0.w" + "=" + memo + "&";
                        }
                        else
                        {
                            postData += "_fm.g._0.w" + "=" + "&"; 
                        }

                        //修改促销方式
                        string promotionString = modifyPromotion ? GetPromotionString(true) : GetPromotionString(false);
                        if (!string.IsNullOrEmpty(promotionString))
                        {
                            postData += promotionString + "&";
                        }

                        //修改店铺促销方式
                        string shopPromotionString = modifyShopPromotion ? GetShopPromotionString(true) : GetShopPromotionString(false);
                        if (!string.IsNullOrEmpty(shopPromotionString))
                        {
                            postData += shopPromotionString + "&";
                        }

                        //修改是否匿名
                        if (modifyAnnoy)
                        {
                            postData += inputControl.Name + "=" + inputControl.Value + "&";
                        }

                        continue;
                    }
                    continue;
                }

                //填写其他地址信息 
                if (inputControl.Control.ToLower() == "select")
                {
                    if (inputControl.Name.ToLower() == "n_prov")
                    {
                        postData += inputControl.Name + "=" + addressInformation.AreaCode.Substring(0, 2) + "0000" + "&";
                        continue;
                    }

                    if (inputControl.Name.ToLower() == "n_city")
                    {
                        postData += inputControl.Name + "=" + addressInformation.AreaCode.Substring(0, 4) + "00" + "&";
                        continue;
                    }

                    if (inputControl.Name.ToLower() == "n_area")
                    {
                        postData += inputControl.Name + "=" + addressInformation.AreaCode + "&";
                        continue;
                    }
                    continue; 
                }

                //填写街道地址信息
                if (inputControl.Control.ToLower() == "textarea")
                {
                    if (inputControl.Name.ToLower() == "_fm.g._0.d")
                    {
                        postData += inputControl.Name + "=" + addressInformation.Address + "&";
                        continue;
                    }
                    continue;
                }
            }

            if (postData.EndsWith("&"))
            {
                postData = postData.Substring(0, postData.Length - 1);
            }

            //更正应付费信息
            postData = Regex.Replace(postData, "actualPaidFee\\s*=.*?&", "actualPaidFee=" + actualFee.ToString() + "&"); 

            //是否满足价格边界条件
            if (applyPriceBorder && actualFee >0 && actualFee > priceBorder)
            {
                lessPriceBorder = false;
            }

            return postData;
        }

        #endregion

        #region 该段代码用于获取action地址
        public string GetOrderActionAddress(string orderPage)
        {
            if (string.IsNullOrEmpty(orderPage))
            {
                auctionLog.Log("警告：传递的订单页面源代码为空");
                return string.Empty;
            }

            Match match = Regex.Match(orderPage, "<form\\s+name\\s*=\\s*\"mainform\"\\s+.*?action\\s*=\\s*\"(?<action>.+?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (match.Success)
            {
                auctionLog.Log("通知：提取了订单页面的action地址：" + match.Groups["action"].ToString());
                return match.Groups["action"].ToString();
            }

            auctionLog.Log("警告：提取旧版订单页面action地址失败");
            return string.Empty;
        }
        #endregion

    }
}
