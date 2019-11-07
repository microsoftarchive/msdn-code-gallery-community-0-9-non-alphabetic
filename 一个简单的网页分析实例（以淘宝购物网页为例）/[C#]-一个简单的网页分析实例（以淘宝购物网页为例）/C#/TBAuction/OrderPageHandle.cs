using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net;

namespace TBAuction
{
    class OrderPageHandle
    {
        AuctionLog auctionLog;
        AuctionOperations auctionOperations;
        CheckCodeForm checkCodeForm;

        public OrderPageHandle(AuctionLog auctionLog)
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

            if (transports != null)
            { transports.Clear(); }
            else
            { transports = new ArrayList(); }
            
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

            checkCode.J_checkCodeUrl = string.Empty;
            checkCode.isCheckCode = string.Empty;
            checkCode.encrypterString = string.Empty;
            checkCode.sid = string.Empty;
            checkCode.gmtCreate = string.Empty;
            checkCode.checkCodeIds = string.Empty;
            checkCode.checkCode = string.Empty;
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

        ArrayList inputControls;

        //用于存储获取newCheckCode信息的类
        public struct CheckCode
        {
            public string J_checkCodeUrl { get; set; }
            public string isCheckCode { get; set; }
            public string encrypterString { get; set; }
            public string sid { get; set; }
            public string gmtCreate { get; set; }
            public string checkCodeIds { get; set; }
            public string checkCode { get; set; }
        }

        CheckCode checkCode = new CheckCode();
       
        //获取表单控件列表
        private void GetOrderFormContent(string orderPage)
        {
            string frmContent, inputContent;
            Match tempMatch;
            
            MatchCollection matches = Regex.Matches(orderPage, "<form\\s+id\\s*=\\s*\"J_Form\"\\s+.*?>.*?<\\s*/\\s*form\\s*>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (matches.Count > 0)
            {
                auctionLog.Log("通知：发现了订单页面中的表单");
                frmContent = matches[0].ToString(); 

                //读取获取newCheckCode的地址
                tempMatch = Regex.Match(frmContent, "J_checkCodeUrl.*?value\\s*=\\s*\"(?<checkCodeUrl>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (tempMatch.Success)
                {
                    checkCode.J_checkCodeUrl = tempMatch.Groups["checkCodeUrl"].ToString(); 
                }

                matches = Regex.Matches(frmContent, "<\\s*(?<control>input|textarea|select).*?>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
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

                            inputControls.Add(inputControl);

                            //读取获取newCheckCode所需的信息
                            if (inputControl.Name.Trim().ToLower() == "ischeckcode" && inputControl.Value.Trim().ToLower() == "true")
                            {
                                checkCode.isCheckCode = "true";
                            }

                            if (inputControl.Name.Trim().ToLower() == "encrypterstring")
                            {
                                checkCode.encrypterString = inputControl.Value;
                            }

                            if (inputControl.Name.Trim().ToLower() == "sid")
                            {
                                checkCode.sid = inputControl.Value;
                            }

                            if (inputControl.Name.Trim().ToLower() == "gmtcreate")
                            {
                                checkCode.gmtCreate = inputControl.Value;
                            }

                            if (inputControl.Name.Trim().ToLower() == "checkcodeids")
                            {
                                checkCode.checkCodeIds = inputControl.Value;
                            }
                            
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
        private struct Transport
        {
            public string Id { get; set; }
            public string Fare { get; set; }
            public string Level { get; set; }
            public string Message { get; set; }
            public string Extra { get; set; }
            public string Select { get; set; }
            public string Cod { get; set; }
        }

        //信息变量定义
        ArrayList transports;
        Promotion promotion = new Promotion();
        ShopPromotion shopPromotion = new ShopPromotion();

        //获取网页信息域
        private string GetOrderInformationDomain(string orderPage)
        {
            Match contentMatch = Regex.Match(orderPage, "promoData(?<content>.*?)usePoint", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
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

            Match postagesMatch = Regex.Match(orderInformationDomain, "postages.*?\\[(?<postages>.*?)\\]", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (postagesMatch.Success)
            {
                auctionLog.Log("通知：发现了订单页面中的postages信息域");
                string postagesString = postagesMatch.Groups["postages"].ToString();
                MatchCollection postageMatches = Regex.Matches(postagesString, "{(?<postage>.+?)}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (postageMatches.Count > 0)
                {
                    auctionLog.Log("通知：在订单页面中发现了运费选项");
                    foreach (Match singlePostage in postageMatches)
                    {
                        //获取一种运输方式的信息字符串
                        string singlePostageString = singlePostage.Groups["postage"].ToString();

                        //获取该种运输方式的属性信息并放入对象
                        Transport transport = new Transport();

                        Match tempMatch = Regex.Match(singlePostageString, "id\\s*\"\\s*:\\s*\"(?<id>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            transport.Id = tempMatch.Groups["id"].ToString();
                        }

                        tempMatch = Regex.Match(singlePostageString, "fare\\s*\"\\s*:\\s*\"(?<fare>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            transport.Fare = tempMatch.Groups["fare"].ToString();
                        }

                        tempMatch = Regex.Match(singlePostageString, "level\\s*\"\\s*:\\s*\"(?<level>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            transport.Level = tempMatch.Groups["level"].ToString();
                        }

                        tempMatch = Regex.Match(singlePostageString, "message\\s*\"\\s*:\\s*\"(?<message>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            transport.Message = tempMatch.Groups["message"].ToString();
                        }

                        tempMatch = Regex.Match(singlePostageString, "extra\\s*\"\\s*:\\s*\"(?<extra>.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            transport.Extra = tempMatch.Groups["extra"].ToString();
                        }

                        tempMatch = Regex.Match(singlePostageString, "select\\s*\"\\s*:\\s*(?<select>true|false)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            transport.Select = tempMatch.Groups["select"].ToString();
                        }

                        tempMatch = Regex.Match(singlePostageString, "cod\\s*\"\\s*:\\s*(?<cod>true|false)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            transport.Cod = tempMatch.Groups["cod"].ToString();
                        }

                        transports.Add(transport);
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

            tempMatch = Regex.Match(orderInformationDomain, "orders.*", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (tempMatch.Success)
            {
                orderInformationDomain = tempMatch.Groups[0].ToString();
            }

            //获取促销信息
            if (!String.IsNullOrEmpty(promotionId))
            {
                tempMatch = Regex.Match(orderInformationDomain, ",\\s*\"\\s*" + promotionId + "(?<promotionInformationDomain>.*?)orderData", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
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

        int actualFee;

        //获取运输方式Id，若未发现则转向获取默认运输方式Id
        private string GetSelectedTransport(string message)
        {
            foreach (Transport transport in transports)
            {
                if (!string.IsNullOrEmpty(message) && transport.Message.Contains(message))
                {
                    actualFee += int.Parse(transport.Fare);
                    auctionLog.Log("通知：发现了指定的运输方式");
                    return transport.Id;
                }                
            }
            auctionLog.Log("警告：未能发现指定的运输方式");
            return GetDefaultTransport();
        }

        private string GetDefaultTransport()
        {
            foreach (Transport transport in transports)
            {
                if (transport.Select.ToLower().Trim() == "true")
                {
                    actualFee += int.Parse(transport.Fare);
                    auctionLog.Log("通知：选择了默认的运输方式");
                    return transport.Id;
                }
            }
            auctionLog.Log("警告：未能发现默认的运输方式");
            return string.Empty;
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
                int maxDiscount = 0;
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
                int maxDiscount = 0;
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
        public string GetOrderPostData(string orderPage,bool modifyQuantity, int quantity, bool modifyTransport, string transport, bool modifyMemo, string memo, bool modifyPromotion, bool modifyShopPromotion, bool modifyAnnoy, bool applyPriceBorder, int priceBorder, out bool lessPriceBorder,CookieContainer cc)
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
            string selectedTansport = string.Empty, defaultTransport = string.Empty;

            if (string.IsNullOrEmpty(promotion.Price))
            {
                auctionLog.Log("警告：未从促销选项中获得价格信息，尝试从整个订单表单数据域中获取");
                Match priceMatch = Regex.Match(orderInformationDomain, "price\\s*\"\\s*:\\s*\"(?<price>\\d+)\\s*\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
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
            if (modifyTransport)
            {
                selectedTansport = GetSelectedTransport(transport);
            }
            else
            {
                defaultTransport = GetDefaultTransport();
            }            

            
            //生成post数据
            foreach (InputControl inputControl in inputControls)
            {
                if (inputControl.Control.ToLower() == "input")
                {
                    if (inputControl.Type.ToLower() == "text")
                    {
                        //是否修改数量
                        if (inputControl.Name.ToLower().Contains("quantity"))
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

                        //填写验证码
                        if (inputControl.Name.ToLower() == "checkcode")
                        {
                            if (checkCode.isCheckCode == "true")
                            {
                                postData = inputControl.Name + "=" + checkCode.checkCode + "&";
                            }
                            else
                            {
                                postData += inputControl.Name + "=" + inputControl.Value + "&";
                            }
                            continue;
                        }

                        postData += inputControl.Name + "=" + inputControl.Value + "&";

                    }
                    if (inputControl.Type.ToLower() == "hidden")
                    {
                        //设置运输方式input(codServiceType)，注意，如果以后淘宝升级免运费状态下不用列表选择，注意将该控件value设置为0
                        if (inputControl.Name.ToLower().Contains("codservicetype") && modifyTransport)
                        {
                            if (modifyTransport)
                            {                                
                                postData += inputControl.Name + "=" + selectedTansport + "&";
                            }
                            else
                            {
                                postData += inputControl.Name + "=" + defaultTransport + "&";
                            }
                        }
                        else
                        {
                            //获取验证码并填充newCheckCode表单字段，注意，这里需要添加验证码识别的部分！！！！！！！！！！！！！！！！！！！！
                            if (inputControl.Name.ToLower() == "newCheckCode" && checkCode.isCheckCode == "true")
                            {
                                auctionLog.Log("通知：可能需要输入验证码");

                                CookieCollection ccReturned;
                                Bitmap image = new Bitmap(auctionOperations.GetCheckCodeImageStream("http://checkcode.taobao.com/auction/checkcode?sessionID=" + checkCode.encrypterString, cc,out ccReturned));
                                cc.Add(ccReturned);
                                checkCodeForm.checkCodePic.Image = image;
                                checkCodeForm.ShowDialog();
                                checkCode.checkCode = checkCodeForm.txtCheckCode.Text.Trim();

                                if (string.IsNullOrEmpty(checkCode.checkCode))
                                {
                                    auctionLog.Log("警告：并未输入验证码");
                                    return string.Empty;
                                }                                
                                
                                string newCheckCode = auctionOperations.GetNewCheckCode(checkCode, cc, out ccReturned);
                                cc.Add(ccReturned);
                                if (string.IsNullOrEmpty(newCheckCode))
                                {
                                    auctionLog.Log("警告：未能成功获取newCheckCode数据");
                                    return string.Empty;
                                }                                

                                postData += inputControl.Name + "=" + newCheckCode + "&";
                            }
                            else
                            {
                                postData += inputControl.Name + "=" + inputControl.Value + "&";
                            }
                        }
                    }

                    //修改是否匿名
                    if (inputControl.Type.ToLower().Trim() == "checkbox" && inputControl.Name.ToLower().Contains("anony") && modifyAnnoy)
                    {
                        postData += inputControl.Name + "=" + inputControl.Value + "&";
                    }

                }

                if (inputControl.Control.ToLower() == "textarea")
                {
                    //修改促销方式
                    string promotionString = modifyPromotion ? GetPromotionString(true) : GetPromotionString(false);
                    if (!string.IsNullOrEmpty(promotionString))
                    {
                        postData += promotionString + "&";
                    }

                    //修改留言
                    if (modifyMemo && !string.IsNullOrEmpty(memo))
                    {
                        postData += inputControl.Name + "=" + memo + "&";
                    }
                    else
                    {
                        postData += inputControl.Name + "=" + inputControl.Value + "&";
                    }

                    //修改店铺促销方式
                    string shopPromotionString = modifyShopPromotion ? GetShopPromotionString(true) : GetShopPromotionString(false);
                    if (!string.IsNullOrEmpty(shopPromotionString))
                    {
                        postData += shopPromotionString + "&";
                    }

                }
                if (inputControl.Control.ToLower() == "select")
                {
                    //修改运输方式Select
                    if (inputControl.Name.ToLower().Contains("post"))
                    {
                        if (modifyTransport)
                        {                            
                            postData += inputControl.Name + "=" + selectedTansport + "&";
                        }
                        else
                        {
                            postData += inputControl.Name + "=" + defaultTransport + "&";
                        }
                    }
                }
            }

            if (postData.EndsWith("&"))
            {
                postData = postData.Substring(0, postData.Length - 1);
            }

            if (applyPriceBorder && actualFee > 0 && actualFee > priceBorder)
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

            Match match = Regex.Match(orderPage, "<form\\s+id\\s*=\\s*\"J_Form\"\\s+.*?action\\s*=\\s*\"(?<action>.+?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (match.Success)
            {
                auctionLog.Log("通知：提取了新版订单页面的action地址：" + match.Groups["action"].ToString());
                return match.Groups["action"].ToString();
            }

            auctionLog.Log("警告：提取新版订单页面action地址失败");
            return string.Empty;
        }
        #endregion

    }
}
