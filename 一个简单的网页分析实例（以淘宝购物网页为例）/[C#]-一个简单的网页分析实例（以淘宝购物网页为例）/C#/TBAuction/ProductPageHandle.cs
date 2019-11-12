using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TBAuction
{
    class ProductPageHandle
    {
        AuctionLog auctionLog;

        private PropertyList propertyList;

        private QuestionForm questionForm;

        public ProductPageHandle(AuctionLog auctionLog)
        {
            this.auctionLog = auctionLog;

            propertyList = new PropertyList();

            questionForm = new QuestionForm();
        }

        //属性标题值对类
        public struct TitleValuePair
        {
            public string Title
            { get; set; }
            public string Value
            { get; set; }
        }

        //属性类
        public struct PropertyType
        {
            public string Name
            { get; set; }
            public ArrayList PropertyList
            { get; set; }
        }

        //sku类
        private struct SkuType
        {
            public string PropertyCombine
            { get; set; }
            public string SkuId
            { get; set; }
            public string Price
            { get; set; }
            public string Stock
            { get; set; }
        }

        //清空所有变量
        public void Init()
        {
            if (productInputDict != null)
            { productInputDict.Clear(); }
            else
            { productInputDict = new Dictionary<string, string>(); }

            if (pts != null)
            { pts.Clear(); }
            else
            { pts = new ArrayList(); }

            if (sts != null)
            { sts.Clear(); }
            else
            { sts = new ArrayList(); }

            skuId = string.Empty;
            skuInfo = string.Empty;
            productPage = string.Empty;

            if (propertyList.Pts != null)
            { propertyList.Pts.Clear(); }
            else
            { propertyList.Pts = new ArrayList(); }

            questionAnswer = string.Empty;
        }
        
        //信息变量定义
        Dictionary<string, string> productInputDict;
        ArrayList pts, sts ;
        string skuId, skuInfo, productPage, questionAnswer;

        //提取表单内容
       public void GetProductFormContent()
        {
            if (string.IsNullOrEmpty(productPage))
            {
                auctionLog.Log("警告：传递的商品页源代码字符串为空");
                return;
            }

           //提取问题并要求回答
           Match questionMatch = Regex.Match(productPage, "<div\\s*class\\s*=\\s*\"\\s*disqualified\\s*\".*?<\\s*br.*?>(?<question>.*?)\\s*<\\s*/\\s*div>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (questionMatch.Success)
            {
                string question = string.Empty;
                string questionContent = questionMatch.Groups["question"].ToString();
                MatchCollection charMatches = Regex.Matches(questionContent, "&#(?<number>\\d+)\\s*;", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (charMatches.Count > 0)
                {
                    foreach (Match match in charMatches)
                    {
                        int charNumber = int.Parse(match.Groups["number"].ToString());
                        question += Convert.ToChar(charNumber);
                    }
                }
                if (!string.IsNullOrEmpty(question))
                {
                    questionForm.lblQuestion.Text = question;
                    questionForm.ShowDialog();
                    questionAnswer = questionForm.txtAnswer.Text.Trim();
                }
            }

            string frmContent, inputContent, tempStr;
            Match tempMatch;

            MatchCollection matches = Regex.Matches(productPage, "<form\\s+id\\s*=\\s*\"J_FrmBid\"\\s+.*?>.*?<\\s*/\\s*form\\s*>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (matches.Count > 0)
            {
                auctionLog.Log("通知：发现了商品页面中表单");
                frmContent = matches[0].ToString();
                //提取各个input控件的内容存入dict字典
                matches = Regex.Matches(frmContent, "<\\s*input.*?>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (matches.Count > 0)
                {
                    auctionLog.Log("通知：在商品页面的表单中发现了input控件");
                    foreach (Match match in matches)
                    {
                        inputContent = match.ToString();
                        tempMatch = Regex.Match(inputContent, "name\\s*=\\s*[\"\'](?<name>.*?)[\"\']", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (tempMatch.Success)
                        {
                            tempStr = tempMatch.Groups["name"].ToString();
                            productInputDict.Add(tempStr, "");
                            tempMatch = Regex.Match(inputContent, "value\\s*=\\s*[\"\'](?<value>.*?)[\"\']", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            productInputDict[tempStr] = tempMatch.Groups["value"].ToString();
                        }
                    }
                }
            }
        }

        //读出商品属性
        private void GetProductProperties()
        {
            if (string.IsNullOrEmpty(productPage))
            {
                auctionLog.Log("警告：传递的商品页源代码字符串为空");
                return;
            }

            PropertyType tempPropertyType;
            string tempPropertyContent;

            MatchCollection tempMatches;


            MatchCollection matches = Regex.Matches(productPage, "<ul\\s+data-property\\s*=\\s*\"(?<name>.*?)\".*?class\\s*=\\s*\"tb-clearfix\\s+J_TSaleProp.*?\".*?<\\s*/\\s*ul\\s*>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (matches.Count > 0)
            {
                auctionLog.Log("通知：在商品页面中发现了属性列表");
                foreach (Match match in matches)
                {
                    tempPropertyType = new PropertyType();
                    tempPropertyType.PropertyList = new ArrayList();
                    tempPropertyType.Name = match.Groups["name"].ToString();
                    tempPropertyContent = match.ToString();
                    tempMatches = Regex.Matches(tempPropertyContent, "<li\\s+data-value\\s*=\\s*\"(?<value>.*?)\".*?>.*?<span\\s*>\\s*(?<title>.*?)\\s*<\\s*/\\s*span\\s*>.*?<\\s*/\\s*li\\s*>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    foreach (Match match1 in tempMatches)
                    {
                        TitleValuePair tvp = new TitleValuePair();
                        tvp.Title = match1.Groups["title"].ToString();
                        tvp.Value = match1.Groups["value"].ToString();
                        tempPropertyType.PropertyList.Add(tvp);
                    }
                    pts.Add(tempPropertyType);
                }
            }

        }

        //读出skuId生成所用信息
        private void GetProductSkuMap()
        {
            if (string.IsNullOrEmpty(productPage))
            {
                auctionLog.Log("警告：传递的商品页源代码字符串为空");
                return;
            }

            Match skuMapMatch = Regex.Match(productPage, "\"skuMap\"\\s*:\\s*\\{(?<content>.*?)<\\s*/\\s*script\\s*>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            String skuMapStr;
            MatchCollection skuMatches;

            SkuType tempSkuType;
            if (skuMapMatch.Success)
            {
                auctionLog.Log("通知：在商品页面中发现了skuMap列表");
                skuMapStr = skuMapMatch.Groups["content"].ToString();
                skuMatches = Regex.Matches(skuMapStr, "\";(?<propertyCombine>.*?);\"\\s*:\\s*\\{\\s*\"skuId\"\\s*:\\s*\"(?<skuId>.*?)\"\\s*,\\s*\"price\"\\s*:\\s*\"(?<price>.*?)\"\\s*,\\s*\"stock\"\\s*:\\s*\"(?<stock>.*?)\"\\s*\\}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match match in skuMatches)
                {
                    tempSkuType = new SkuType();
                    tempSkuType.PropertyCombine = match.Groups["propertyCombine"].ToString();
                    tempSkuType.SkuId = match.Groups["skuId"].ToString();
                    tempSkuType.Price = match.Groups["price"].ToString();
                    tempSkuType.Stock = match.Groups["stock"].ToString();
                    sts.Add(tempSkuType);
                }
            }
        }

        //获取特定属性组合的skuId和skuInfo信息
        private void GetProductSkuInformation(string propertyCombine)
        {
            string[] properties = propertyCombine.Split(';');

            ArrayList dataValue = new ArrayList();

            foreach (string property in properties)
            {
                bool flag = false;
                foreach (PropertyType pt in pts)
                {

                    foreach (TitleValuePair tvp in pt.PropertyList)
                    {
                        if (tvp.Title.Trim().Contains(property.Trim())) //property.Trim() == tvp.Title.Trim())注意，此处为模糊和精确匹配的问题
                        {
                            skuInfo += pt.Name + ":";
                            skuInfo += tvp.Title.Trim() + ";";
                            dataValue.Add(tvp.Value.Trim());
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
            }

            if (skuInfo.Length > 2)
            {
                skuInfo = skuInfo.Substring(0, skuInfo.Length - 1);
                auctionLog.Log("通知：在商品页面中获取了skuInfo：" + skuInfo);
            }
           
            if (dataValue.Count > 0)
            {
                auctionLog.Log("通知：在商品页面的属性列表中发现传递的属性值");
                foreach (SkuType st in sts)
                {
                    bool flag = true;
                    foreach (string str in dataValue)
                    {
                        if (!st.PropertyCombine.Contains(str))
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        skuId = st.SkuId;
                        auctionLog.Log("通知：在商品页面的skuMap列表中发现了传递的属性值的skuId:" + skuId);
                        return;
                    }
                }
            }

        }

        //获取postData字符串
        public string GetProductPostData(string productPage, string propertyCombine, bool showPropertyList, out bool isSkuidNull, out string questionAnswer)
        {
            isSkuidNull = false;
            questionAnswer = string.Empty;

            if (string.IsNullOrEmpty(productPage))
            {
                auctionLog.Log("警告：传递的商品页源代码字符串为空");
                return string.Empty;
            }

            this.productPage = productPage;

            string postData = string.Empty;

            GetProductFormContent();
            questionAnswer = this.questionAnswer;
            if (productInputDict.Count < 1)
            {
                auctionLog.Log("警告：在商品页面中没有发现input控件");
                return string.Empty;
            }

            GetProductProperties();
            if (pts.Count > 0 && showPropertyList)
            {
                propertyList.Pts = pts;
                propertyList.ShowDialog();
                propertyCombine = propertyList.PropertiesString;                
                auctionLog.Log("通知：用户自己选择了属性信息");
            }

            GetProductSkuMap();

            if (pts.Count > 0 && sts.Count >0 && !string.IsNullOrEmpty(propertyCombine))
            {
                GetProductSkuInformation(propertyCombine);
            }

            if (string.IsNullOrEmpty(skuId))
            {
                auctionLog.Log("警告：未发现指定属性的skuId");
                isSkuidNull = true;
            }

            foreach (KeyValuePair<string, string> kvp in productInputDict)
            {
                if (kvp.Key.ToLower().Trim() == "skuid")
                {
                    if (string.IsNullOrEmpty(skuId) && sts.Count > 0)
                    {
                        skuId = ((SkuType)sts[0]).SkuId;
                        auctionLog.Log("警告：默认选择了第一个skuId");
                    }
                    
                    postData += kvp.Key + "=" + skuId + "&";
                    
                    continue;
                }
                if (kvp.Key.ToLower().Trim() == "skuinfo")
                {
                    postData += kvp.Key + "=" + skuInfo + "&";
                    continue;
                }               

                postData += kvp.Key + "=" + kvp.Value + "&";
            }

            if (postData.EndsWith("&"))
            {
                postData = postData.Substring(0, postData.Length - 1);
            }

            return postData;
        }

        //获取action地址
        public string GetProductActionAddress(string productPage)
        {
            if (string.IsNullOrEmpty(productPage))
            {
                auctionLog.Log("警告：传递的产品页面源代码为空");
                return string.Empty;
            }

            Match match = Regex.Match(productPage, "<form\\s+id\\s*=\\s*\"J_FrmBid\"\\s+.*?action\\s*=\\s*\"(?<action>.+?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (match.Success)
            {
                auctionLog.Log("通知：提取了商品页面的action地址：" + match.Groups["action"].ToString());
                return match.Groups["action"].ToString();                
            }
            auctionLog.Log("警告：提取商品页面action地址失败");
            return string.Empty;
        }       
    }
}
