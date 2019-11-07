using System;
using System.Windows.Forms;
using System.Net;

namespace TBAuction
{
    public partial class frmAuction : Form
    {
        public frmAuction()
        {
            InitializeComponent();

            isLoged = false;
            auctionLog = new AuctionLog(false);
            orderPageHandle = new OrderPageHandle(auctionLog);
            orderPageHandleOld = new OrderPageHandleOld(auctionLog);
            orderPageHandleQuestion = new OrderPageHandleQuestion(auctionLog);
            productPageHandle = new ProductPageHandle(auctionLog);
            auctionOperations = new AuctionOperations(auctionLog);
        }

        private bool isLoged;
        private AuctionLog auctionLog;
        private OrderPageHandle orderPageHandle;
        private OrderPageHandleOld orderPageHandleOld;
        private OrderPageHandleQuestion orderPageHandleQuestion;
        private ProductPageHandle productPageHandle;
        private AuctionOperations auctionOperations;
        private CookieContainer cc = new CookieContainer();
        private CookieCollection ccReturned;

        //用于实现CookieContainer的复制操作
        private CookieContainer GetCookieContainerCopy(CookieContainer CC)
        {
            CookieContainer newCC = new CookieContainer();
            newCC.Capacity = cc.Capacity;            
            newCC.MaxCookieSize = cc.MaxCookieSize;
            newCC.PerDomainCapacity = cc.PerDomainCapacity;
            newCC.Add(CC.GetCookies(new Uri("http://www.taobao.com")));
            newCC.Add(CC.GetCookies(new Uri("http://www.tmall.com")));

            return newCC;
        }  

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("请输入用户名！");
                txtName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("请输入密码！");
                txtPassword.Focus();
                return;
            }
            auctionLog.ShowForm();
            isLoged = auctionOperations.Login(txtName.Text.Trim(), txtPassword.Text.Trim(),out ccReturned);
            cc.Add(ccReturned);

            if (isLoged)
            {
                auctionLog.Log("通知：登录成功");
                btnLogin.Text = "重新登录";
            }
            else
            {
                auctionLog.Log("警告：登录失败");
            }

        }

        private void AuctionOperation()
        {
            int interval = 0;
            if (chkInterval.Checked)
            {
                interval = int.Parse(txtInterval.Text.Trim());
            }

            if (chkTeminateTime.Checked && DateTime.Now > DateTime.Parse(txtTeminateTime.Text.Trim()))
            { return; }

            if (interval > 0)
            {
                System.Threading.Thread.Sleep(interval);
            }

            string productAddress = txtAddress.Text.Trim();
           
            string productPage = auctionOperations.GetProductPage(productAddress,GetCookieContainerCopy(cc), out ccReturned);

            if (productPage.IndexOf("J_LinkBuy") < 0)
            {
                AuctionOperation();
                return;
            } 

            cc.Add(ccReturned);           

            if (string.IsNullOrEmpty(productPage))
            {
                auctionLog.Log("警告：商品页面为空，重新尝试");
                AuctionInit();
                AuctionOperation();
                return;
            }

            string orderAddress = productPageHandle.GetProductActionAddress(productPage);

            if (string.IsNullOrEmpty(orderAddress))
            {
                auctionLog.Log("警告：从商品页面返回的action地址为空，重新尝试");
                AuctionInit();
                AuctionOperation();
                return;
            }

            bool isSkuidNull;
            string questionAnswer;
            string productPostData = productPageHandle.GetProductPostData(productPage, txtProperties.Text.Trim(), chkProperties.Checked, out isSkuidNull, out questionAnswer);
            if (string.IsNullOrEmpty(questionAnswer))
            {
                auctionLog.Log("通知：未发现需要回答的问题");
            }
            if (chkSkuidNull.Checked && isSkuidNull)
            {
                auctionLog.Log("警告：因skuId为空而退出抢拍");
                return; 
            }
            if (string.IsNullOrEmpty(productPostData))
            {
                auctionLog.Log("警告：未能从商品页面获取post数据，重新尝试");
                AuctionInit();
                AuctionOperation();
                return;
            }

            //可能不需要
            //string marketingReturn = auctionOperations.GetMarketingInformation(productAddress, cc);
            //if (string.IsNullOrEmpty(marketingReturn))
            //{
            //    auctionLog.Log("警告：获取营销信息失败");
            //    return;
            //}
            
            //可能不需要
            //string preOrderReturn = auctionOperations.PreSubmitProductPage(productAddress, cc);
            //if (string.IsNullOrEmpty(preOrderReturn))
            //{
            //    auctionLog.Log("警告：预提交失败");
            //    return;
            //}
            
            string orderPage = auctionOperations.SubmitProductPage(productAddress, orderAddress, productPostData, GetCookieContainerCopy(cc), out ccReturned);
            if (string.IsNullOrEmpty(orderPage))
            {
                auctionLog.Log("警告：订单页面为空，重新尝试");
                AuctionInit();
                AuctionOperation();
                return;
            }
            cc.Add(ccReturned);

            bool lessPriceBorder;
            string orderPostData;
            string resultAddress;
            string submitAddress = orderPageHandle.GetOrderActionAddress(orderPage);
            
            if (string.IsNullOrEmpty(submitAddress))
            {
                auctionLog.Log("警告：未发现新版订单网页");
                submitAddress = orderPageHandleOld.GetOrderActionAddress(orderPage);
                if (string.IsNullOrEmpty(submitAddress))
                {
                    auctionLog.Log("警告：未发现旧版订单网页");
                    submitAddress = orderPageHandleQuestion.GetOrderActionAddress(orderPage);
                    if (string.IsNullOrEmpty(submitAddress))
                    {
                        auctionLog.Log("警告：未发现答题订单网页");
                        AuctionInit();
                        AuctionOperation();
                        return;
                    }
                    else
                    {
                        auctionLog.Log("通知：发现了答题订单网页");                        
                        orderPostData = orderPageHandleQuestion.GetOrderPostData(orderPage, chkQuantity.Checked, int.Parse(txtQuantity.Text.Trim()), chkTransport.Checked, txtTransport.Text.Trim(), chkMemo.Checked, txtMemo.Text.Trim(), chkPromotion.Checked, chkShopPromotion.Checked, chkAnoy.Checked, chkPriceBorder.Checked, int.Parse(txtPriceBorder.Text.Trim()), out lessPriceBorder, cc, questionAnswer);
                        if (!lessPriceBorder)
                        {
                            AuctionInit();
                            AuctionOperation();
                            return;
                        }
                        if (string.IsNullOrEmpty(orderPostData))
                        {
                            auctionLog.Log("警告：未能从答题订单网页中获取post数据，重新尝试");
                            AuctionInit();
                            AuctionOperation();
                            return;
                        }
                        resultAddress = auctionOperations.SubmitOrder(submitAddress, orderPostData, GetCookieContainerCopy(cc), out ccReturned);
                        cc.Add(ccReturned);
                        if (resultAddress.IndexOf("正在处理中，请稍候") > -1)
                        {
                            auctionLog.Log("通知：竞拍成功，请自行付款");
                            return;
                        }
                        else
                        {
                            auctionLog.Log("警告：竞拍可能失败，重新尝试");
                            AuctionInit();
                            AuctionOperation();
                            return;
                        }
                    }                  
                    
                }
                auctionLog.Log("通知：发现了旧版订单网页");                
                orderPostData = orderPageHandleOld.GetOrderPostData(orderPage, chkQuantity.Checked, int.Parse(txtQuantity.Text.Trim()), chkTransport.Checked, txtTransport.Text.Trim(), chkMemo.Checked, txtMemo.Text.Trim(), chkPromotion.Checked, chkShopPromotion.Checked, chkAnoy.Checked, chkPriceBorder.Checked, int.Parse(txtPriceBorder.Text.Trim()), out lessPriceBorder, cc, questionAnswer);
                if (!lessPriceBorder)
                {
                    AuctionInit();
                    AuctionOperation();
                    return;
                }
                if (string.IsNullOrEmpty(orderPostData))
                {
                    auctionLog.Log("警告：未能从旧版订单网页中获取post数据，重新尝试");
                    AuctionInit();
                    AuctionOperation();
                    return;
                }
                resultAddress = auctionOperations.SubmitOrder(submitAddress, orderPostData, GetCookieContainerCopy(cc), out ccReturned);
                cc.Add(ccReturned);
                if (resultAddress.IndexOf("正在处理中，请稍候") > -1)
                {
                    auctionLog.Log("通知：竞拍成功，请自行付款");
                    return;
                }
                else
                {
                    auctionLog.Log("警告：竞拍可能失败，重新尝试");
                    AuctionInit();
                    AuctionOperation();
                    return;
                }
            }
            else
            {
                auctionLog.Log("通知：发现了新版订单网页");                
                //注意新版网页中还未得到过有回答问题的网页！！！！！！！！！！！！！！！！
                orderPostData = orderPageHandle.GetOrderPostData(orderPage, chkQuantity.Checked, int.Parse(txtQuantity.Text.Trim()), chkTransport.Checked, txtTransport.Text.Trim(), chkMemo.Checked, txtMemo.Text.Trim(), chkPromotion.Checked, chkShopPromotion.Checked, chkAnoy.Checked, chkPriceBorder.Checked, int.Parse(txtPriceBorder.Text.Trim()), out lessPriceBorder,cc);
                if (!lessPriceBorder)
                {
                    AuctionInit();
                    AuctionOperation();
                    return;
                }
                resultAddress = auctionOperations.SubmitOrder(submitAddress, orderPostData, GetCookieContainerCopy(cc),out ccReturned);
                cc.Add(ccReturned);
                if (string.IsNullOrEmpty(orderPostData))
                {
                    auctionLog.Log("警告：未能从新版订单网页中获取post数据，重新尝试");
                    AuctionInit();
                    AuctionOperation();
                    return;
                }              

                if (resultAddress.IndexOf("正在处理中，请稍候") > -1)
                {
                    auctionLog.Log("通知：竞拍成功，请自行付款");
                    return;
                }
                else
                {
                    auctionLog.Log("警告：竞拍可能失败，重新尝试");
                    AuctionInit();
                    AuctionOperation();
                    return;
                }
            }

        }

        private void AuctionInit()
        {
            productPageHandle.Init();
            orderPageHandle.Init();
            orderPageHandleOld.Init();
            orderPageHandleQuestion.Init();
        }

        private void btnAuct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                txtAddress.Focus();
                return;
            }

            if (isLoged)
            {
                if (chkBeginTime.Checked)
                {
                    int interval = 500;
                    if (chkInterval.Checked)
                    {
                        interval = int.Parse(txtInterval.Text.Trim());
                    }

                    while (true)
                    {
                        DateTime dt = DateTime.Parse(txtBeginTime.Text.Trim());
                        if (DateTime.Now < dt)
                        {
                            System.Threading.Thread.Sleep(interval);
                        }
                        else
                        {
                            break;
                        }
                    }
                   
                }
                AuctionInit();
                AuctionOperation();
            }
        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAuction_Load(object sender, EventArgs e)
        {
            txtBeginTime.Text = DateTime.Now.ToString();
            txtTeminateTime.Text = (DateTime.Now.AddMinutes(3d)).ToString();
        }

        private void chkLog_CheckedChanged(object sender, EventArgs e)
        {
            auctionLog.SetShow(chkLog.Checked);
            if (chkLog.Checked)
            {
                auctionLog.ShowForm();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            auctionLog.ShowFormForce();
        }       
    }
}
 