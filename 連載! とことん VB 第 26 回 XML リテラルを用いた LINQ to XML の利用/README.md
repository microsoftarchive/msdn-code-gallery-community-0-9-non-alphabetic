# 連載! とことん VB: 第 26 回 XML リテラルを用いた LINQ to XML の利用
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2008
- Visual Studio 2010
## Topics
- VB プログラミング
- 連載 VB
## Updated
- 02/13/2011
## Description
<style><!-- ﻿.showRatings{border-bottom:silver 1px solid;background-color:#f0f0f0;text-align:left;width:100%;height:28px;vertical-align:bottom;}.showRatings_right{z-index:99;float:right;} ﻿.CodeHighlighter{word-wrap:break-word;}pre{white-space:pre-wrap;white-space:-moz-pre-wrap;white-space:o-pre-wrap;}
 ﻿.ShareThisMainPanel{text-align:left;float:left;}.ShareThis_RootButton{cursor:pointer;border:solid 0 #000;display:inline;margin-top:5px;margin-bottom:15px;margin-right:10px;}.ShareThis_BtnLink{vertical-align:middle;color:#000;font-weight:700;}.ShareThis_RootButton_Image{padding-left:5px;vertical-align:middle;}.ShareThis_ChildRootPanel{top:211px;left:6px;color:#000;width:auto;height:auto;padding:2px;z-index:1000;text-align:left;}.ShareThisBrand_X
 img{vertical-align:bottom;}.TierOneButtons1{border:solid 0 blue;cursor:pointer;min-width:135px;}.tierTwoPanel{border:solid 0 blue;cursor:pointer;min-width:135px;border-top:solid 1px #999;clear:both;width:140px;}.tierTwoHorizontal{border:solid 0 blue;cursor:pointer;float:left;min-width:135px;width:140px;}.tierTwoRowPanel{border:solid
 0 blue;cursor:pointer;float:left;min-width:135px;display:inline;}.buttonPanel{border-bottom:solid 0 orange;padding:4px 0 4px 4px;margin-bottom:2px;vertical-align:top;float:left;}.buttonPanelHyperLink{margin-left:4px;}.iconsOnPanel{height:16px;width:16px;vertical-align:bottom;}.STMain{text-align:left;float:left;}
 ﻿.VCR_Container{position:relative;}.VCR_GroupLabel{color:#333;font-weight:bold;padding:5px 0 1px;}.VCR_GroupLabel:first-child{padding-top:0;}.VCR_Label{border-left:1px solid #fff;border-bottom:1px solid #fff;color:#06d;cursor:pointer;margin:2px 0 0 0;padding:1px
 0 2px 4px;}.VCR_Label_Focussed{background:#e3e3e3 url('../../images/common.png') 0 -74px repeat-x;border-left:1px solid #c2c2c2;border-bottom:1px solid #c2c2c2;color:#f60;}.VCR_Label_Selected{background:#e3e3e3 url('../../images/common.png') 0 -74px repeat-x;border-left:1px
 solid #c2c2c2;border-bottom:1px solid #c2c2c2;}.VCR_ContentItem{background-color:#fff;display:none;padding-left:12px;overflow:hidden;position:absolute;top:13px;right:0;bottom:0;left:0;}.VCR_CheckBox{cursor:pointer;position:absolute;top:0;right:4px;}.VCR_CheckBoxImage{background:#260859
 url('../../images/common.png') -37px -1px no-repeat;display:block;height:17px;width:15px;}.VCR_CheckBoxHover .VCR_CheckBoxImage{background-color:#0072bc;}.VCR_CheckBoxPlaying .VCR_CheckBoxImage{background-position:-51px -1px;}.VCR_CheckBoxImage{background-color:#260859;}.VCR_CheckBoxHover
 .VCR_CheckBoxImage{background-color:#0072bc;}.StoTeaserHolder{height:26px;}.Stotickler{background-color:#f1f1f1;border-bottom:solid 1px #aaa;height:26px;position:absolute;top:0;width:100%;z-index:14;}.cpsPosCss{margin:0 auto;max-width:0;padding:0 483px;width:0;}#lspLink{background-image:url('../../images/gsfx_eie_icon_dkbg.png');background-repeat:no-repeat;height:24px;margin:0
 -477px;position:absolute;white-space:nowrap;}#lspLink a{font-size:12px;color:#333;text-decoration:none;position:relative;left:32px;top:4px;}#lspLink a:active,#lspLink a:hover{cursor:pointer;color:#333;text-decoration:underline;}#lspTile{background-image:url('../../images/cps_ie_canvas.png');background-repeat:no-repeat;background-color:Transparent;border:solid
 1px #ccc;display:none;float:left;height:133px;left:0;margin:0 -470px;padding:0;position:relative;top:5px;width:423px;z-index:15;}#lspAdd{position:absolute;left:270px;bottom:2px;margin:0;padding:0;float:left;}#lspClose{width:13px;height:13px;position:relative;left:406px;top:4px;margin:0;padding:0;cursor:pointer;float:left;}#lspClose
 img,#lspAdd img{border:none;}#lspDontShow{margin:0;padding:0;position:absolute;top:111px;left:8px;float:left;}#lspDontShow a{color:#48819c;font-family:Tahoma;text-decoration:underline;}#lspDontShow a:active,#lspDontShow a:hover{cursor:pointer;}#cps{position:relative;z-index:1001;}#cpsPosCss{height:24px;}.Stoteaserhidden{display:none;height:0;}#lspTile{filter:progid:DXImageTransform.Microsoft.Alpha(opacity=1,scale=3);}.internav{background-position:top
 right;background-repeat:no-repeat;float:left;font-family:'Segoe UI Semibold','Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:14px;height:32px;margin:0 0 0 8px;max-width:936px;overflow:hidden;padding:0 37px 0 0;position:relative;white-space:nowrap;}.leftcap{height:32px;left:-29px;position:absolute;width:37px;}.internav
 a{float:left;margin:0;padding:6px 9px;white-space:nowrap;}.internav a:hover{height:20px;margin:1px 0;padding:6px 9px 4px 9px;}.internav a.active,.internav a.active:hover{background:url('../../images/common.png') 0 -43px no-repeat;height:20px;margin:1px 0;padding:5px
 9px;}.LocalNavigation{display:inline-block;font-size:12px;margin:2px 0 0 -17px;padding:0 0 1px 0;white-space:nowrap;width:996px;}.HeaderTabs{margin:0 0 0 25px;width:948px;}.LocalNavigation .TabOff{float:left;white-space:nowrap;}.LocalNavigation .TabOff a{float:left;margin-top:1px;padding:4px
 6px;cursor:pointer;}.LocalNavigation .TabOff a:hover{padding:5px 6px 3px 6px;}.LocalNavigation .TabOn{float:left;margin-top:1px;padding:4px 6px;white-space:nowrap;}.LocalNavigation .TabOn a,.LocalNavigation .TabOn a:hover,.LocalNavigation .TabOn a:visited{cursor:default;text-decoration:none;}.LocalNavBottom{display:none;}.cleartabstrip{clear:both;height:0;}div.ShareThis2{white-space:nowrap;display:block;position:relative;}div.ShareThis2
 a{display:inline-block;background:#fff;}div.ShareThis2 a span.Icon,div.ShareThis2 ul li a span span.Icon{display:inline-block;background-image:url('../../images/headlinesprites.png');background-repeat:no-repeat;width:16px;height:16px;}div.ShareThis2 a span.Label{color:#858585;font-size:85%;position:relative;bottom:4px;}div.ShareThis2
 ul{display:none;background:#fff;padding:5px;position:absolute;left:-9px;list-style:none;margin:0;padding:5px 10px 5px 10px;border:1px solid #ddd;}div.ShareThis2Up ul{bottom:25px;}div.ShareThis2Down ul{top:25px;}div.ShareThis2 ul li{position:relative;list-style:none;padding:3px
 3px 3px 3px;margin:0;}div.ShareThis2 ul li a span{display:inline-block;}div.ShareThis2 ul li a span span.Label{display:inline-block;font-size:90%;position:relative;bottom:3px;padding-left:1px;}div.ShareThis2 a span.Icon{background-position:-89px 0;}div.ShareThis2
 ul li a span span.ShareThisEmail{background-position:-241px 0;}div.ShareThis2 ul li a span span.ShareThisFacebook{background-position:-122px 0;}div.ShareThis2 ul li a span span.ShareThisTwitter{background-position:-138px 0;}div.ShareThis2 ul li a span span.ShareThisDigg{background-position:-154px
 0;}div.ShareThis2 ul li a span span.ShareThisTechnorati{background-position:-170px 0;}div.ShareThis2 ul li a span span.ShareThisDelicious{background-position:-186px 0;}div.ShareThis2 ul li a span span.ShareThisGoogle{background-position:-202px 0;}div.ShareThis2
 ul li a span span.ShareThisMessenger{background-position:-218px 0;}div.ShareThis2 a span.Icon{position:relative;left:-2px;top:-3px;}.SearchBox{background-color:#fff;border:solid 1px #346b94;float:left;margin:0 0 12px 0;width:314px;}.TextBoxSearch{border:none;color:#000;float:left;font-size:13px;font-style:normal;margin:0;padding:4px
 0 0 5px;vertical-align:top;width:232px;}.Bing{background:#fff url('../../images/common.png') 0 -20px no-repeat;display:inline-block;float:right;height:22px;overflow:hidden;text-align:right;width:47px;}.SearchButton{background:#fff url('../../images/common.png')
 -48px -19px no-repeat;display:inline-block;border-width:0;cursor:pointer;float:right;height:21px;margin:0;padding:0;text-align:right;vertical-align:top;width:21px;}#SuggestionContainer li{list-style:none outside none;}.TextBoxSearchIE7{padding:2px 2px 0 5px;border:solid
 1px #fff;}div.DivRatingsOnly{border:solid 0 red;margin-top:5px;margin-bottom:5px;}.ratingStar{font-size:0;width:16px;height:16px;margin:0;padding:0;cursor:pointer;display:block;background-repeat:no-repeat;}.filledRatingStar{background:url('/Areas/Sto/Content/Theming/Images/LibC.gif')
 -288px 0;float:left;}.emptyRatingStar{background:url('/Areas/Sto/Content/Theming/Images/LibC.gif') -304px 0;float:left;}.savedRatingStar{background:url('/Areas/Sto/Content/Theming/Images/LibC.gif') -272px 0;float:left;}.tbFont{white-space:nowrap;}* html .tbfont,*+html
 .tbfont{font-size:70%;}.tableCss{border-collapse:collapse;}.tableCellRateCss{text-align:left;line-height:70%;}.tableCellRateControlCss{width:85px;}.LocaleManagementFlyoutPopup{background-color:#fff;color:#000;border:1px solid #b8b8b8;text-align:left;z-index:1000;padding:3px;display:none;position:absolute;}.LocaleManagementFlyoutPopup
 A,.LocaleManagementFlyoutPopup A:visited{font-size:10px;color:#000;height:15px;text-align:left;text-decoration:none;white-space:nowrap;display:block;padding:1px 3px;}.LocaleManagementFlyoutPopup A:hover,.LocaleManagementFlyoutPopup A:active{background-color:#f0f7fd;height:15px;text-decoration:none;white-space:nowrap;display:block;padding:1px
 3px;}.LocaleManagementFlyoutPopupHr{height:1px;background:#d0e0f0;margin:0 11px 21px;}.LocaleManagementFlyoutPopArrow{background:transparent url('/Areas/Sto/Content/Images/arrow_dn_white.gif') no-repeat;padding-bottom:4px;padding-left:5px;margin-right:10px;}.LocaleManagementFlyoutStatic,.LocaleManagementFlyoutStaticHover{white-space:nowrap;text-decoration:none;cursor:default;display:inline;margin:1px;padding:1px
 3px;}A.LocaleManagementFlyoutStaticLink,A:visited.LocaleManagementFlyoutStaticLink,A:active.LocaleManagementFlyoutStaticLink{white-space:nowrap;text-decoration:none;display:inline;}A:hover.LocaleManagementFlyoutStaticLink{text-decoration:underline;}div.HeadlineRotator{clear:both;}div.HeadlineRotator
 span.Items{display:inline-block;position:relative;cursor:default;}div.HeadlineRotator span.Items .Item{position:absolute;margin:0;}div.HeadlineRotator span.Items span.Title{display:none;}div.HeadlineRotator div.Controls{display:inline-block;height:32px;background:#fff;}div.HeadlineRotator
 div.Controls a.Control{background-color:#919999;position:relative;display:inline-block;cursor:pointer;background-image:url('../../images/headlinesprites.png');background-repeat:no-repeat;width:24px;margin:9px 2px 0 2px;height:21px;float:left;}div.HeadlineRotator
 div.Controls a.ControlRight{background-position:-48px 0;margin-right:18px;}div.HeadlineRotator div.Controls a.Control:hover{background-color:#4d6c97;}div.HeadlineRotator div.Controls span.ControlDots{float:left;display:block;margin:11px 0 0 4px;}div.HeadlineRotator
 div.Controls a.ControlDot{width:17px;height:17px;margin:0;background-position:-72px 0;background-color:#e2e8ed;}div.HeadlineRotator div.Controls a.ControlDot:hover{background-color:#8dace7;}div.HeadlineRotator div.Controls a.ControlDotSelected,.HeadlineRotator
 div.Controls a.ControlDotSelected:hover{background-color:#6d8ca7;}div.HeadlineViewer div.Controls div.RightControls{display:block;float:right;display:inline-block;margin:12px 4px 0 0;}div.HeadlineViewer div.Controls div.RightControls a.ControlRss,div.HeadlineViewer
 div.Controls div.RightControls div.ShareThis2{display:block;float:right;}div.HeadlineViewer div.Controls div.RightControls div.ShareThis2 span.Icon{margin-right:4px;}div.HeadlineViewer div.Controls div.RightControls a.ControlRss span.Icon,div.HeadlineNews
 a.ControlRss span.Icon{position:relative;bottom:1px;margin-left:16px;display:inline-block;background-image:url('../../images/headlinesprites.png');background-position:-105px 0;width:17px;height:17px;}div.HeadlineNews a.ControlRss span.Icon{bottom:-1px;margin-left:11px;}div.HeadlineNews{margin-right:-30px;}div.HeadlineNews
 div.ItemCont{background:#f3f3f7;margin-bottom:25px;margin-right:29px;float:left;}div.HeadlineNews a.Item{display:inline-block;height:206px;overflow:hidden;margin-bottom:5px;}div.HeadlineNews h2.NewsTitle{padding:0 0 10px 4px;font-weight:100;}div.HeadlineNews
 h2.NewsTitle span.Last{font-family:"Segoe UI Light","Segoe UI","Lucida Grande",Verdana,Arial,Helvetica,sans-serif;font-weight:200;}div.HeadlineNews span.Image{display:block;overflow:hidden;margin-bottom:6px;}div.HeadlineNews span.Title{display:block;padding:5px
 5px 6px 5px;font-size:120%;}div.HeadlineNews span.Description,div.HeadlineNews span.Description:hover,div.HeadlineNews span.Description:active{display:block;padding:0 5px 4px 5px;color:#000;line-height:16px;}div.HeadlineList{display:inline-block;margin-bottom:10px;}div.HeadlineList
 div.Items{display:inline-block;}div.HeadlineList div.ItemsWithHeaderImage{padding:13px 21px 0 13px;}div.HeadlineList a.Item{width:100%;}div.HeadlineList a.Item span{display:inline-block;}div.HeadlineList div.Items .ShareThis2Cont{margin-bottom:20px;}div.HeadlineList
 div.Items .ShareThis2{float:right;position:relative;top:-4px;}div.HeadlineList a.Item .Description,div.HeadlineList a.Item span.Description:hover,div.HeadlineList a.Item span.Description:active{display:inline-block;color:#000;margin-bottom:10px;}div.HeadlineNews
 div.ItemCont{margin-bottom:25px;margin-right:20px;}div.HeadlineNews{margin-right:0;}div.HeadlineViewer div.Controls div.RightControls a.ControlRss span.Icon,div.HeadlineNews a.ControlRss span.Icon{top:-3px;left:16px;}div.HeadlineList div.Items .ShareThis2{float:right;position:relative;top:0;}.FooterLinks{padding:6px
 0 12px 8px;}.FooterLinks A{color:#03c;font-weight:normal;}A.FooterLinks:hover{color:#f60;}.FooterCopyright{color:#333;font-weight:normal;padding-right:8px;}.Pipe{color:#000;font-size:125%;padding:0 4px;}.FeedViewerBasicIdentification{display:none;}.MtpsFeedViewerBasicRootPanelClass{clear:left;margin:0
 5px 5px 0;padding:0 5px 5px 0;vertical-align:top;width:auto;}.MtpsFeedViewerBasicHeaderStylePanel{vertical-align:middle;margin-bottom:10px;}.FVB_HeaderStyle_One,.FVB_HeaderStyle_Two,.FVB_HeaderStyle_Three,.FVB_HeaderStyle_Four,.FVB_HeaderStyle_Five{font-weight:900;}.FVB_HeaderStyle_One{font-size:200%;}.FVB_HeaderStyle_Two{font-size:175%;}.FVB_HeaderStyle_Three{font-size:150%;}.FVB_HeaderStyle_Four{font-size:125%;}.FVB_HeaderStyle_Five{font-size:100%;}A.TitleRSSButtonCssClass{vertical-align:middle;}A.TitleRSSButtonCssClass
 img{margin:0 0 0 5px;}.BasicHeadlinesItemPanelCssClass{float:left;margin-bottom:10px;padding:0 1% 0 0;vertical-align:top;}.BasicListItemPanelCssClass{float:left;margin-bottom:15px;padding:0 0 0 1%;vertical-align:top;}.FeedViewerBasicBulletListLI{margin-bottom:5px;}.FeatureHeadlinesTitle{margin-top:0;padding-top:0;vertical-align:top;}.TitleBold{font-weight:700;}.FeaturedHeadlinesItemPanelCssClass{float:left;padding:0
 1% 0 0;vertical-align:top;}.ImageHeadlineTabelCell{padding:0 5px 0 0;text-align:left;vertical-align:top;width:1%;}.ImageHeadlineTabelCell A IMG{border:solid 0 transparent;}.FeaturedRssItemTableCell{vertical-align:top;padding-bottom:12px;text-align:left;}.FVBAuthorLabel{font-weight:900;color:#555;font-size:smaller;padding:0
 5px 0 0;}.FVBPubDateLabel{font-style:italic;color:#555;font-size:smaller;}.FVB_ImageHeadlinesDiv{margin-bottom:10px;vertical-align:top;}.LimitedListItemPanelCssClass{float:left;vertical-align:top;margin-bottom:15px;padding:0 1% 0 0;}.ItemDiv{float:left;padding:0
 1% 0 0;}.ColumnDiv{clear:both;margin-top:15px;}.OverflowAuto{overflow:auto;}.OPMLImgDiv{float:left;margin-bottom:12px;padding:3px 10px 9px 0;}.OPMLTextDiv{vertical-align:top;min-height:30px;margin:0 0 12px 65px;}.OPMLFriendlyName{font-size:small;font-weight:bold;}.OPMLSubtitle{font-size:small;font-weight:normal;}.OPMLFriend{text-decoration:none;color:#555;}.FVBForumListLI{margin-bottom:10px;}.FVBForumDescriptionCssClass{width:auto;vertical-align:top;margin-bottom:15px;}.ListColumnPanel{float:left;padding-right:1%;}.EmptyPanel{clear:both;}.ListPanelMarginTop{margin-top:15px;}.TitleHidden{visibility:hidden;height:0;}.FR_Thumb
 .FR_Thumb_Border1{margin-left:5px;padding:1px;border:1px solid #ccc;background:#eee;}.FR_Thumb .FR_Thumb_Border2{border:2px solid #eee;}.FR_Thumb_Focussed .FR_Thumb_Border1{background:#ccc;}.FR_Thumb_Selected .FR_Thumb_Border1{background:#999;}.FR_Image .FR_Image_Border1{padding:2px;border:1px
 solid #ccc;background:#eee;margin-left:25px;}.FR_Image .FR_Image_Border2{border:1px solid #eee;position:relative;}.FR_Text{text-align:right;position:absolute;bottom:0;left:0;right:0;}.FR_Text_Left{text-align:left;}.FR_Background{position:absolute;bottom:0;left:0;right:0;background-color:#000;-moz-opacity:.5;filter:alpha(opacity=50);opacity:.5;z-index:0;}.FR_TextContainer{padding:8px;z-index:10;}.FR_Title{font-family:'Segoe
 UI Bold','Segoe Bold','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:14px;font-weight:bold;color:#fff;}.FR_Description{font-size:12px;color:#fff;}.BP_Home_Renew{margin:10px 10px 10px 0;}.BP_Home_Renew table{margin:0 auto;}.BP_Home_ExpirationText{text-align:center;}.BP_Home_RenewLink{padding-right:10px;text-align:center;}.BP_Home_Table
 ul{padding:10px 0 0 15px;font-size:14px;margin:0;}.BP_Home_Table ul li{list-style-image:none;list-style-type:none;padding-bottom:2px;}.BP_Home_Renew * input{padding:4px;vertical-align:middle;}#GutterNavigation{margin:-8px 0 0 0;text-align:left;width:180px;z-index:1;}.GutterTitle{font-size:12px;font-weight:bold;padding:8px
 0 0 7px;}.BostonNavCtrlButton,.BostonNavCtrlButton:active,.BostonNavCtrlButton:link,.BostonNavCtrlButton:visited{display:block;padding:1px 2px 1px 14px;text-decoration:none;}.BostonNavCtrlButton:hover{background-color:#ededed;color:#333;}.MoreCentersLink:active,.MoreCentersLink:visited,.MoreCentersLink:link{display:block;text-decoration:none;text-align:right;}.ratingsPopup{background-color:#fff;border:#7a7a7a
 1px solid;margin:0;width:450px;height:220px;vertical-align:middle;position:absolute;z-index:100;display:none;}.ratingsPopup .OptionalText{margin-top:10px;margin-bottom:10px;float:left;margin-left:25px;font-size:10pt;}.ratingsPopup .ratingsComment{width:396px;display:block;margin-bottom:10px;margin-left:25px;height:132px;}.ratingsPopup
 .RatingsCloseButton,.ratingsPopup .RatingsSubmitButton{float:right;margin-left:25px;padding-top:.2em;}.ratingsPopup .RatingsCloseButton{margin-right:25px;}.Rotate90{-webkit-transform:rotate(90deg);-moz-transform:rotate(90deg);-o-transform:rotate(90deg);-khtml-transform:rotate(90deg);width:0;height:0;}.AlternatePages{position:absolute;left:964px;white-space:nowrap;}span.AlternatePageTab{cursor:pointer;display:inline-block;padding:5px;margin:3px;background-color:transparent;border:1px
 solid #ddd;border-bottom:1px solid transparent;position:relative;bottom:2px;color:#000;}span.AlternatePageTabHover{background:#eee;border:1px solid #888;border-bottom:1px solid #eee;}span.AlternatePageTabSelected{cursor:default;background-color:#fff;border:1px
 solid #aaa;border-bottom:1px solid #fff;bottom:2px;}.Rotate90{writing-mode:tb-rl;}span.AlternatePageTab{border:1px solid #ddd;border-left:1px solid transparent;bottom:0;left:2px;}span.AlternatePageTabSelected{border:1px solid #aaa;border-left:1px solid transparent;bottom:0;left:2px;}html,body,div,span,applet,object,iframe,h1,h2,h3,h4,h5,h6,p,blockquote,pre,a,abbr,acronym,address,big,cite,code,del,dfn,em,font,img,ins,kbd,q,s,samp,small,strike,strong,sub,sup,tt,var,dl,dt,dd,ol,ul,li,fieldset,form,label,legend,table,caption,tbody,tfoot,thead,tr,th,td{border:0;font-weight:inherit;font-style:inherit;font-family:inherit;margin:0;outline:0;padding:0;}table{border-collapse:separate;border-spacing:0;}html{font-size:100.01%;}body{color:#333;font-family:'Segoe
 UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:80%;line-height:130%;}a,a:link,a:visited{color:#06d;cursor:pointer;text-decoration:none;}a:hover,a:active{color:#f60;text-decoration:none;}.bold,strong{font-weight:bold;}code{font-family:'Courier
 New',Courier,monospace;}em{font-style:italic;}h1,.title,h2,h3,h4,h5,h6{color:#3a3e43;font-weight:bold;line-height:125%;}h1,.title{font-size:175%;}h2{font-size:160%;margin:4px 0;}h3{font-size:140%;line-height:140%;margin:3px 0;}h4{font-size:125%;margin:2px
 0;}h5{font-size:110%;}h6{font-size:105%;}.Clear{clear:both;height:0;}.ClearBreak{clear:both;padding-bottom:1px;}.Clearleft{clear:left;height:0;}.ClearRight{clear:right;height:0;}.ClearRightBreak{clear:right;height:16px;}.clearnone{clear:none;}.Left{float:left;}.Right{float:right;}.Center{text-align:center;}.no_wrap{white-space:nowrap;}p{margin:0
 0 12px 0;}.absolute{position:absolute;}ol,ul{line-height:150%;margin:12px 0 12px 24px;}li{padding:0 0 3px 0;}ul li,ol>ul li{list-style-image:url('../../images/bullet.gif');}ol li,ul>ol li{list-style-image:none;}.bulletedlist,.BulletList{line-height:150%;list-style-type:disc;margin:12px
 0 12px 24px;}.NumberList{margin:12px 0 12px 24px;}.DropDownArrow{padding-bottom:2px;padding-left:5px;}a:hover .DropDownArrow{text-decoration:none;}.hidden{display:none;visibility:hidden;}.pre{margin:10px;padding:10px;}.code{background:#ddd;display:block;font-family:'Lucida
 Console','Courier New';font-size:100%;line-height:100%;margin:10px;padding:10px;}#BodyBackground{padding:0 483px;}#JelloSizer{margin:0 auto;max-width:0;padding:0;width:0;}#JelloExpander{margin:0 -483px;min-width:966px;position:relative;}#JelloWrapper{width:100%;}.skipnav
 a{position:absolute;left:-10000px;overflow:hidden;}.skipnav a:focus,.skipnav a:active{position:static;left:0;overflow:visible;}table.multicol{border-collapse:collapse;}.innercol{padding:0 12px 0 0;}.BostonPostCard{margin:0 0 12px 0;overflow:hidden;width:100%;}.BostonPostCard
 h1,.BostonPostCard h2,.BostonPostCard h3,.BostonPostCard h4,.BostonPostCard h5,.BostonPostCard h6{height:26px;margin:0 0 10px 0;overflow:hidden;position:relative;white-space:nowrap;}.MainColumn .BostonPostCard,.maincolumn .BostonPostCard,.MiddleColumn .BostonPostCard,.middlecolumn
 .BostonPostCard{margin:0 -12px 12px 0;padding:0 12px 0 0;}.RightAdRail .BostonPostCard{margin:0 0 12px 0;}.BostonPostCard h1{font-size:160%;height:31px;}.BostonPostCard h2{font-size:140%;height:28px;padding:3px 0 0 0;}.BostonPostCard h3{font-size:125%;}.BostonPostCard
 h4{font-size:110%;height:24px;}.BostonPostCard h5{font-size:105%;height:23px;}.BostonPostCard h6{font-size:100%;height:31px;line-height:100%;}.rssfeed,.rssfeed:hover{background:transparent url('../../images/common.png') -19px -1px no-repeat;display:inline-block;height:17px;position:relative;width:17px;}.opmlfeed,.opmlfeed:hover{background:transparent
 url('../../images/common.png') -1px -1px no-repeat;display:inline-block;height:17px;position:relative;width:17px;}.RightAdRail .BostonPostCard h1 .rssfeed,.RightAdRail .BostonPostCard h1 .opmlfeed,.RightAdRail .BostonPostCard h2 .rssfeed,.RightAdRail .BostonPostCard
 h2 .opmlfeed,.BostonPostCard h3 .rssfeed,.BostonPostCard h3 .opmlfeed,.BostonPostCard h4 .rssfeed,.BostonPostCard h4 .opmlfeed,.BostonPostCard h5 .rssfeed,.BostonPostCard h5 .opmlfeed,.BostonPostCard h6 .rssfeed,.BostonPostCard h6 .opmlfeed{position:absolute;right:0;top:4px;}td.headlines_td_text{padding:0
 0 12px 10px;}td.headlines_td_text strong{font-size:14px;font-weight:normal;margin-bottom:3px;}td.headlines_td_image{padding:3px 0 12px 0;}table.headlines_table{padding-bottom:12px;}td.noimages_td{}.RightAdRail .linklist{margin-top:-12px;}.linklist h3{font-size:14px;font-weight:bold;}.BostonPostCard
 .linklist h3{font-size:14px;font-weight:bold;margin-bottom:0;}.expressWrapper{margin-left:15px;margin-top:15px;width:790px;}.expressQPWrapper{margin-left:645px;margin-top:25px;}.expressQPCell{height:43px;padding-left:20px;}table.grid{border:solid #666 1px;}.grid
 td{padding:5px;border:solid #333 1px;}.CollapseRegionLink,.CollapseRegionLink:link,.CollapseRegionLink:hover,.CollapseRegionLink:visited{font-size:inherit!important;}Div.miniRatings{height:auto!important;vertical-align:middle!important;padding-bottom:5px!important;padding-top:5px!important;}div.miniRatings_left{padding-top:0!important;padding-bottom:0!important;position:inherit!important;background-color:Transparent!important;}div.miniRatings_left
 a{padding-top:0!important;padding-bottom:0!important;}div.clsNote{background-color:#eee;margin-bottom:4px;padding:2px;}.bookbox{clear:none;float:right;text-align:center;width:300px;}.bookpublisherlogocontainer{margin-top:5px;}.BreadCrumb{font-size:90%;padding:5px
 0 10px;}.EyebrowElement{font-weight:bold;}.SmallTitle{font-size:140%;}.clearfix:after{content:".";display:block;clear:both;visibility:hidden;line-height:0;height:0;}.clearfix{display:inline-block;}html[xmlns] .clearfix{display:block;}* html .clearfix{height:1%;}.AlternativeLocales{padding:10px
 2px 10px 2px;}p.NoP{margin:0;}.Container p{margin:0;display:block;}div.NoBrandLogo A{background:transparent;color:#fff;height:auto;width:auto;}div.NoBrandLogo span{display:inline;}.RightAdRail2{background-color:#fafafa;}div.PaddedMainColumnContent{padding-left:5px;}ol{padding-left:10px;}table.multicol{border-collapse:collapse;}.FullWidth,.fullwidth{overflow:hidden;}.MainColumn,.maincolumn{overflow:hidden;}.MiddleColumn,.middlecolumn{overflow:hidden;}.RightColumn,.rightcolumn{overflow:hidden;}.LeftNavigation,.leftnavigation{overflow:hidden;}.ColumnFifty,.columnfifty,.RightAdRail{overflow:hidden;}h1,.title{margin:5px
 0;}h1,.title,h2,h3,h4,h5,h6{clear:both;font-family:'Segoe UI Semibold','Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;}.Masthead{padding:12px 0 0 0;}.BrandLogo{cursor:pointer;font-family:'Segoe UI Semibold','Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:19px;float:left;line-height:125%;margin:0
 0 0 8px;width:312px;}.GlobalBar{float:right;font-size:12px;margin:-4px 11px 0 0;text-align:right;width:305px;}.GlobalBar a:hover{text-decoration:underline;}.PassportScarab{float:right;padding:0;white-space:nowrap;}.UserName{float:right;font-size:13px;font-weight:bold;overflow:hidden;white-space:nowrap;width:283px;}.LocaleManagementFlyoutStaticLink{margin-right:16px;}LocaleManagementFlyoutStaticLink
 a,LocaleManagementFlyoutStaticLink a:visited,LocaleManagementFlyoutStaticLink a:active{white-space:nowrap;text-decoration:none;display:inline;}LocaleManagementFlyoutStaticLink a:hover{text-decoration:underline;}.NetworkLogo{font-family:'Segoe UI Semibold','Segoe
 UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:19px;line-height:150%;position:absolute;right:12px;}.NetworkLogo a{display:inline-block;height:21px;width:79px;}.alley{background:url('../images/contentpanemiddle.png') repeat-y left;padding-left:19px;}.wrapper{padding-right:21px;}.topleftcorner{background:transparent
 url('../images/contentpane.png') 0 0 no-repeat;height:17px;margin-top:-2px;margin-right:21px;}.toprightcorner{background:transparent url('../images/contentpane.png') 100% 0 no-repeat;float:right;height:17px;margin-top:-17px;width:21px;}.inner{min-height:768px;padding:1px;}.bottomleftcorner{background:transparent
 url('../images/contentpane.png') 0 -17px no-repeat;height:21px;margin-right:21px;}.bottomrightcorner{background:transparent url('../images/contentpane.png') 100% -17px no-repeat;float:right;height:21px;margin-top:-21px;width:21px;}.BostonPostCard h1 a,.BostonPostCard
 h2 a,.BostonPostCard h3 a,.BostonPostCard h4 a,.BostonPostCard h5 a,.BostonPostCard h6 a{color:#260859;}.BostonPostCard h1,.BostonPostCard h2,.BostonPostCard h3,.BostonPostCard h4,.BostonPostCard h5,.BostonPostCard h6{background:url('../../images/headers.gif')
 0 0 no-repeat;}.BostonPostCard h2{padding:3px 0 0 0;}.BostonPostCard h3{padding:5px 0 0 0;}.BostonPostCard h4{padding:7px 0 0 0;}.BostonPostCard h5{padding:8px 0 0 0;}.FullWidth .BostonPostCard h1,.fullwidth .BostonPostCard h1,.FullWidth .BostonPostCard h2,.fullwidth
 .BostonPostCard h2,.MainColumn .BostonPostCard h1,.maincolumn .BostonPostCard h1,.MainColumn .BostonPostCard h2,.maincolumn .BostonPostCard h2,.MiddleColumn .BostonPostCard h1,.middlecolumn .BostonPostCard h1,.MiddleColumn .BostonPostCard h2,.middlecolumn
 .BostonPostCard h2,.LeftNavigation .BostonPostCard h1,.leftnavigation .BostonPostCard h1,.LeftNavigation .BostonPostCard h2,.leftnavigation .BostonPostCard h2,.RightColumn .BostonPostCard h1,.rightcolumn .BostonPostCard h1,.RightColumn .BostonPostCard h2,.rightcolumn
 .BostonPostCard h2,.ColumnFifty .BostonPostCard h1,.columnfifty .BostonPostCard h1,.ColumnFifty .BostonPostCard h2,.columnfifty .BostonPostCard h2{background:none;}.FullWidth .BostonPostCard h3,.fullwidth .BostonPostCard h3,.FullWidth .BostonPostCard h4,.fullwidth
 .BostonPostCard h4,.FullWidth .BostonPostCard h5,.fullwidth .BostonPostCard h5,.FullWidth .BostonPostCard h6,.fullwidth .BostonPostCard h6{background-position:-1px -98px;}.MainColumn .BostonPostCard h3,.maincolumn .BostonPostCard h3,.MainColumn .BostonPostCard
 h4,.maincolumn .BostonPostCard h4,.MainColumn .BostonPostCard h5,.maincolumn .BostonPostCard h5,.MainColumn .BostonPostCard h6,.maincolumn .BostonPostCard h6{background-position:-302px -66px;}.MiddleColumn .BostonPostCard h3,.middlecolumn .BostonPostCard h3,.MiddleColumn
 .BostonPostCard h4,.middlecolumn .BostonPostCard h4,.MiddleColumn .BostonPostCard h5,.middlecolumn .BostonPostCard h5,.MiddleColumn .BostonPostCard h6,.middlecolumn .BostonPostCard h6{background-position:-483px -34px;}.LeftNavigation .BostonPostCard h3,.leftnavigation
 .BostonPostCard h3,.LeftNavigation .BostonPostCard h4,.leftnavigation .BostonPostCard h4,.LeftNavigation .BostonPostCard h5,.leftnavigation .BostonPostCard h5,.LeftNavigation .BostonPostCard h6,.leftnavigation .BostonPostCard h6{background-position:-302px
 -34px;}.RightColumn .BostonPostCard h3,.rightcolumn .BostonPostCard h3,.RightColumn .BostonPostCard h4,.rightcolumn .BostonPostCard h4,.RightColumn .BostonPostCard h5,.rightcolumn .BostonPostCard h5,.RightColumn .BostonPostCard h6,.rightcolumn .BostonPostCard
 h6{background-position:-1px -130px;}.ColumnFifty .BostonPostCard h3,.columnfifty .BostonPostCard h3,.ColumnFifty .BostonPostCard h4,.columnfifty .BostonPostCard h4,.ColumnFifty .BostonPostCard h5,.columnfifty .BostonPostCard h5,.ColumnFifty .BostonPostCard
 h6,.columnfifty .BostonPostCard h6{background-position:-1px -34px;}.RightAdRail .BostonPostCard h1,.RightAdRail .BostonPostCard h2,.RightAdRail .BostonPostCard h5{background-position:-1px -34px;}.RightAdRail .BostonPostCard h3,.RightAdRail .BostonPostCard
 h4,.RightAdRail .BostonPostCard h6{background-position:-1px -66px;text-align:right;}.RightAdRail .BostonPostCard h3{padding:5px 7px 0 0;}.RightAdRail .BostonPostCard h4{padding:7px 7px 0 0;}.RightAdRail .BostonPostCard h6{padding:0 31px 0 0;}.RightAdRail .BostonPostCard
 h6 .rssfeed,.RightAdRail .BostonPostCard h6 .opmlfeed{right:7px;top:7px;}.RightAdRail .BostonPostCard h3 .rssfeed,.RightAdRail .BostonPostCard h3 .opmlfeed,.RightAdRail .BostonPostCard h4 .rssfeed,.RightAdRail .BostonPostCard h4 .opmlfeed{position:static;}.pasco_wrapper{background:#fff
 url('../images/pasco_wrapper.gif') -300px -0 repeat-y;margin:0 0 12px 0;overflow:hidden;width:300px;}.RightAdRail .pasco_wrapper h3{background:#fff url('../images/pasco_wrapper.gif') -0 -0 no-repeat;font-size:0;height:36px;margin:0;overflow:hidden;padding:0;}.RightAdRail
 .pasco_wrapper h5{background:#fff url('../images/pasco_wrapper.gif') -0 -36px no-repeat;height:34px;overflow:hidden;}.RightAdRail .pasco_container{padding:0 11px 22px 17px;}.pasco_container ul li{list-style-image:url('../../images/bullet.gif')!important;}.FullWidth
 .h3,.fullwidth .h3{background:url('../../images/headers.gif') -1px -98px no-repeat!important;}.MainColumn .h3,.maincolumn .h3{background:url('../../images/headers.gif') -302px -66px no-repeat!important;}.MiddleColumn .h3,.middlecolumn .h3{background:url('../../images/headers.gif')
 -483px -34px no-repeat!important;}.RightColumn .h3,.rightcolumn .h3{background:url('../../images/headers.gif') -1px -130px no-repeat!important;}.ColumnFifty .h3,.columnfifty .h3{background:url('../../images/headers.gif') -1px -34px no-repeat!important;}.FullWidth
 .h3,.fullwidth .h3,.MainColumn .h3,.maincolumn .h3,.MiddleColumn .h3,.middlecolumn .h3,.RightColumn .h3,.rightcolumn .h3,.ColumnFifty .h3,.columnfifty .h3{font-size:125%!important;height:26px;padding:5px 0 0 0;}.h3 .rssfeed,.h3 .opmlfeed{position:absolute;right:0;top:4px;}ol{padding-left:10px;}.BostonPostCard
 h1{line-height:130%;}.BostonPostCard h6{font-size:95%;line-height:120%;padding:0 0 1px 0;} ﻿#BodyBackground{background:#ced5db url('../images/logos_and_bg.png') repeat-x 0 -100px;}.BrandLogo,.BrandLogo a,.BrandLogo a:link,.BrandLogo a:visited,.BrandLogo a:hover,.BrandLogo
 a:active,.GlobalBar,.PassportScarab,.PassportScarab a,.PassportScarab a:link,.PassportScarab a:visited,.PassportScarab a:hover,.PassportScarab a:active,.UserName,.UserName a,.UserName a:link,.UserName a:visited,.UserName a:hover,.UserName a:active,a.LocaleManagementFlyoutStaticLink,a:link.LocaleManagementFlyoutStaticLink,a:visited.LocaleManagementFlyoutStaticLink,a:hover.LocaleManagementFlyoutStaticLink,a:active.LocaleManagementFlyoutStaticLink{color:#313131;}.NetworkLogo
 a{background:url('../images/logos_and_bg.png') no-repeat 0 0;}.leftcap{background:url('../images/tabstrip.png') no-repeat -997px 0;}.rightcap{background:url('../images/tabstrip.png') no-repeat right top;}.internav{background:url('../images/tabstrip.png') no-repeat
 right top;}.internav a,.internav a:link,.internav a:visited,.internav a:hover{color:#260859;}.internav a:hover{background-color:#fff;}.internav a.active,.internav a.active:link,.internav a.active:hover,.internav a.active:visited,.internav a.active:active{background-color:#becbd7;color:#313131;}.LocalNavigation{background:url('../images/tabstrip.png')
 repeat-y left top;}.LocalNavigation .TabOn,.LocalNavigation .TabOn:hover{background-color:#046cb6;}.LocalNavigation .TabOn a,.LocalNavigation .TabOn a:hover,.LocalNavigation .TabOn a:visited{color:#fff;}.LocalNavigation .TabOff a{color:#313131;}.LocalNavigation
 .TabOff a:hover{background-color:#e8e8e8;}.BostonPostCard h1,.BostonPostCard h2,.BostonPostCard h3,.BostonPostCard h4,.BostonPostCard h5,.BostonPostCard h6{background-color:#e8e8e8;color:#260859;}.RightAdRail .BostonPostCard h1,.RightAdRail .BostonPostCard
 h2,.RightAdRail .BostonPostCard h5{color:#260859;}.RightAdRail .BostonPostCard h3,.RightAdRail .BostonPostCard h4,.RightAdRail .BostonPostCard h6{color:#260859;}.RightAdRail .BostonPostCard h1 a,.RightAdRail .BostonPostCard h2 a,.RightAdRail .BostonPostCard
 h3 a,.RightAdRail .BostonPostCard h4 a,.RightAdRail .BostonPostCard h5 a,.RightAdRail .BostonPostCard h6 a{color:#260859;}.FullWidth .h3,.fullwidth .h3,.MainColumn .h3,.maincolumn .h3,.MiddleColumn .h3,.middlecolumn .h3,.RightColumn .h3,.rightcolumn .h3,.ColumnFifty
 .h3,.columnfifty .h3{background-color:#e8e8e8!important;}.top1,.boxheader{background:#e8e8e8;color:#260859!important;}.boxcontent{border-bottom:1px solid #e8e8e8!important;border-left:1px solid #e8e8e8!important;border-right:1px solid #e8e8e8!important;} ﻿.BrandLogo
 a{background:url('../../images/logos_and_bg.png') no-repeat 0 -23px;display:block;width:79px;height:21px;}.BrandLogo span,.NetworkLogo a{display:none;}.NetworkLogo,.NetworkLogo a,.NetworkLogo a:link,.NetworkLogo a:visited,.NetworkLogo a:hover,.NetworkLogo
 a:active{color:#046cb6;} body{font-family:Verdana,Arial,Helvetica,sans-serif;color:#000;font-size:68.75%}a{text-decoration:none;color:#03c}a:link{color:#03c}a:visited{color:#800080}a:hover{color:#f60}a:active{color:#800080}a img{border:none}H1{font-size:210%;font-weight:400}H1.heading{font-size:120%;font-family:Verdana,Arial,Helvetica,sans-serif;font-weight:bold;line-height:120%}H2{font-size:115%;font-weight:700}H2.subtitle{font-size:180%;font-weight:400;margin-bottom:.6em}H3{font-size:110%;font-weight:700}H4,H5,H6{font-size:100%;font-weight:700}h4.subHeading{font-size:100%}dl{margin:0
 0 10px;padding:0 0 0 1px}dt{font-style:normal;margin:0}li{margin-bottom:3px;margin-left:0}ol{line-height:140%;list-style-type:decimal;margin-bottom:15px}ol ol{line-height:140%;list-style-type:lower-alpha;margin-bottom:4px;margin-top:3px}ol ol ol{line-height:140%;list-style-type:lower-roman;margin-bottom:4px;margin-top:3px}ol
 ul,ul ol{line-height:140%;margin-bottom:15px;margin-top:15px}p{margin:0 0 10px;padding:0}div.section p{margin-bottom:15px;margin-top:0}ul{line-height:140%;list-style-position:outside;list-style-type:disc;margin-bottom:15px}ul ul{line-height:140%;list-style-type:disc;margin-bottom:4px;margin-left:17px;margin-top:3px}.heading{font-weight:700;margin-bottom:8px;margin-top:18px}.subHeading{font-size:100%;font-weight:700;margin:0}div.hr1{background:#c8cdde;font-size:1px;height:1px;margin:0;padding:0;width:100%}div.hr2{background:#d4dfff;font-size:1px;height:1px;margin:0;padding:0;width:100%}div.hr3{background:#eef;font-size:1px;height:1px;margin:0;padding:0;width:100%}div#header{background-color:#d4dfff;padding:0;width:100%}div#header
 table td{color:#00f;margin-bottom:0;margin-top:0;padding-right:20px}div#header table tr#headerTableRow3 td{padding-bottom:2px;padding-top:5px}div#header table#bottomTable{border-top-color:#fff;border-top-style:solid;border-top-width:1px;text-align:left}div#footer{font-size:90%;margin:0;padding:2px
 2px 6px 5px;width:100%}div#mainSection table{border:1px solid #ddd;font-size:100%;margin-bottom:5px;margin-left:5px;margin-top:5px;margin-right:10px;width:97%}div#mainSection table tr{vertical-align:top}div#mainSection table th{border-bottom:1px solid #c8cdde;color:#006;padding-left:5px;padding-right:5px;text-align:left}div#mainSection
 table td{border-right:1px solid #d5d5d3;margin:1px;padding-left:5px;padding-right:5px;overflow:auto}div#mainSection table td.imageCell{white-space:nowrap}DIV#mainSection TABLE.MtpsTableLayout{BORDER:0}DIV#mainSection TABLE.MtpsTableLayout TD{PADDING-RIGHT:5px;PADDING-LEFT:5px;MARGIN:1px;BORDER:0}div.ContentArea
 table th,div.ContentArea table td{background:#fff;border:0 solid #ccc;font-family:Verdana;padding:5px;text-align:left;vertical-align:top}.ContentArea .topic table td{border:1px solid #ccc;margin:1px;padding-left:5px;padding-right:5px}div.ContentArea table
 th{background:#ccc none repeat scroll 0% 50%;vertical-align:bottom}div.ContentArea table{border-collapse:collapse;width:auto}.ContentArea .topic table{border-width:1px;border-style:solid}.media img{vertical-align:top}.HeaderCaptionText,.title{color:#000;font-family:Arial,Helvetica,sans-serif;font-size:190%;font-style:normal;font-variant:normal;font-weight:bold;line-height:normal;margin:0
 0 10px}div#mainBody div.alert,div#mainBody div.code{width:98.9%}div#mainBody div.alert{padding-bottom:.82em;clear:both}span.selflink{font-weight:700}span.code{font-family:Monospace,Courier New,Courier;font-size:105%;color:#006}span.label,span.ui{font-family:"Segoe
 UI",\2018 Lucida Grande\2019 ,Verdana,Arial,Helvetica,sans-serif;font-weight:bold}span.code{font-family:Monospace,Courier New,Courier;font-size:105%;color:#006}div.caption{font-weight:bold;font-size:100%;color:#039}.procedureSubHeading{font-size:110%;font-weight:bold}span.sub{vertical-align:sub}span.sup{vertical-align:super}span.big{font-size:larger}span.small{font-size:smaller}span.tt{font-family:Courier,"Courier
 New",Consolas,monospace}.ContentArea .topic table#topTable{border-width:0;width:100%}.ContentArea .topic table #runningHeaderText{color:#000}.parameter{font-family:"Segoe UI",\2018 Lucida Grande\2019 ,Verdana,Arial,Helvetica,sans-serif;font-size:100%;font-style:italic;margin:0}div.clsNote{background-color:#eee;margin-bottom:4px;padding:2px}.bookbox{float:right;clear:none;width:300px;text-align:center}.bookPublisherLogoContainer{margin-top:5px}.uml{list-style:none!important;margin-left:20px}.uml
 li{list-style-image:none!important}.umlNumber{position:relative;width:150px;left:-154px;text-align:right;padding-right:2px}.umlContent{position:relative;top:-15px} --></style>
<div class="topic" id="topic">
<div id="top">
<div class="Clear"></div>
<div class="Clear"></div>
<p>更新日: 2010 年 6 月 11 日</p>
<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#yajima" target="_blank">
エディフィストラーニング株式会社 矢嶋 聡</a></p>
<div style="margin:0; background-color:#d9e8ec; border:2px #46689a solid">
<div style="background-color:#d9e8ec; border:1px #ffffff solid">
<div style="padding:5px; font-size:100%; border:1px #46689a solid">
<p style="margin:0; padding:0">この記事は、「MSDN プログラミング シリーズ」として発行している技術書籍「<a title="新しいウィンドウで開きます" href="http://www.amazon.co.jp/%E3%82%B9%E3%83%86%E3%83%83%E3%83%97%E3%82%A2%E3%83%83%E3%83%97Visual-Basic-2010%EF%BD%9E%E9%96%8B%E7%99%BA%E8%80%85%E3%81%8C%E3%82%82%E3%81%86%E4%B8%80%E6%AD%A9%E4%B8%8A%E9%81%94%E3%81%99%E3%82%8B%E3%81%9F%E3%82%81%E3%81%AE%E5%BF%85%E8%AA%AD%E3%82%A2%E3%83%89%E3%83%90%E3%82%A4%E3%82%B9%EF%BC%81-MSDN%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0-%E3%82%A8%E3%83%87%E3%82%A3%E3%83%95%E3%82%A3%E3%82%B9%E3%83%88%E3%83%A9%E3%83%BC%E3%83%8B%E3%83%B3%E3%82%B0%E6%A0%AA%E5%BC%8F%E4%BC%9A%E7%A4%BE/dp/4822294269/ref=sr_1_1?ie=UTF8&s=books&qid=1278865722&sr=1-1" target="_blank"><strong>ステップアップ
 Visual Basic 2010 ～開発者がもう一歩上達するための必読アドバイス</strong></a>」(日経 BP 社刊) を基に先進的なテクニックを紹介しています。</p>
</div>
</div>
</div>
<hr>
<h2>目次</h2>
<ol>
<li><a href="#01">はじめに</a> </li><li><a href="#02">LINQ to XML の基本操作</a> </li><li><a href="#03">LINQ to XML 対応の XML データのオブジェクト</a> </li><li><a href="#04">XML リテラルを使用した簡潔な XML データ構築</a> </li><li><a href="#05">XML 軸プロパティを使用した簡潔なアクセス</a> </li><li><a href="#06">XML リテラルと埋め込み式を使用した動的な XML データ作成</a> </li><li><a href="#07">LINQ to XML による XML データ変換</a> </li></ol>
<hr>
<h2 id="01">1. はじめに</h2>
<p>今回は、LINQ を用いて XML を操作する際に使用する「LINQ to XML」について取り上げます。「LINQ to XML」は、メモリ内の XML データを扱うためのプログラミング インターフェイスの 1 種であり、LINQ の観点からいうと「LINQ プロバイダ」の 1 つです。</p>
<p>この「LINQ to XML」は .NET Framework に標準で実装されたもので、.NET Framework 対応言語であれば利用することができます。さらに Visual Basic では、「LINQ to XML」 向けの XML データを簡潔に表現できる「XML リテラル」という固有の表記方法や、それに関連して「XML 軸プロパティ」、「埋め込み式」などの固有の構文があります。これらを用いることで、XML データに関わるコーディングの可読性も向上し、生産性や保守性の向上につながります。</p>
<p>この後半では、こうした「XML リテラル」ほか、LINQ to XML にまつわる Visual Basic 固有の構文についても取り上げます。</p>
<p style="margin-top:20px"><a href="#top"><img src="16921-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. LINQ to XML の基本操作</h2>
<p>まずは、LINQ to XML での基本的なクエリ操作を確認しましょう。次の例は、XML ファイルを読み込み、LINQ のクエリ式を用いて、抽出条件を満たす XML データを取得する例です。 (このコードでは、いつものようにフォームには 1 つのボタンと 1 つのリストボックスが貼り付けてあることが前提です。)</p>
<p><strong>例 1. LINQ to XML を使用した基本的なクエリ (ソースコード)</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;<br>&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button1_Click(...)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button1.Click&nbsp;&larr;&nbsp;Clickイベントハンドラ&nbsp;<br>&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;doc1&nbsp;=&nbsp;XDocument.Load(<span class="visualBasic__string">&quot;XMLFile1.xml&quot;</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">1</span>]&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;query1&nbsp;=&nbsp;From&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;doc1.Descendants(<span class="visualBasic__string">&quot;Customer&quot;</span>)&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">2</span>]&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Where&nbsp;c.Element(<span class="visualBasic__string">&quot;Country&quot;</span>).Value&nbsp;=&nbsp;<span class="visualBasic__string">&quot;USA&quot;</span>&nbsp;<br>&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;query1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">3</span>]&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListBox1.Items.Add(&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Element(<span class="visualBasic__string">&quot;CustomerID&quot;</span>).Value&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;&quot;</span>&nbsp;&amp;&nbsp;c.Element(<span class="visualBasic__string">&quot;CompanyName&quot;</span>).Value)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;<br>&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<br>&nbsp;&nbsp;<br><span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>上記で使用するテキストファイル (XMLFile1.xml)</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">XML</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">xml</span>

<pre id="codePreview" class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-8&quot;</span>&nbsp;<span class="xml__tag_start">?&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&larr;[4]&nbsp;<br><span class="xml__tag_start">&lt;Customers</span><span class="xml__tag_start">&gt;&nbsp;<br></span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;Customer</span><span class="xml__tag_start">&gt;&nbsp;<br></span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;CustomerID</span><span class="xml__tag_start">&gt;</span>ERNSH<span class="xml__tag_end">&lt;/CustomerID&gt;</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;CompanyName</span><span class="xml__tag_start">&gt;</span>Ernst&nbsp;Handel<span class="xml__tag_end">&lt;/CompanyName&gt;</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Country</span><span class="xml__tag_start">&gt;</span>USA<span class="xml__tag_end">&lt;/Country&gt;</span>&nbsp;<br>&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Customer&gt;</span>&nbsp;<br>&nbsp;&nbsp;<span class="xml__tag_start">&lt;Customer</span><span class="xml__tag_start">&gt;&nbsp;<br></span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;CustomerID</span><span class="xml__tag_start">&gt;</span>QUICK<span class="xml__tag_end">&lt;/CustomerID&gt;</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;CompanyName</span><span class="xml__tag_start">&gt;</span>QUICK-Stop<span class="xml__tag_end">&lt;/CompanyName&gt;</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Country</span><span class="xml__tag_start">&gt;</span>Germany<span class="xml__tag_end">&lt;/Country&gt;</span>&nbsp;<br>&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Customer&gt;</span>&nbsp;<br>&nbsp;&nbsp;<span class="xml__tag_start">&lt;Customer</span><span class="xml__tag_start">&gt;&nbsp;<br></span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;CustomerID</span><span class="xml__tag_start">&gt;</span>SAVEA<span class="xml__tag_end">&lt;/CustomerID&gt;</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;CompanyName</span><span class="xml__tag_start">&gt;</span>Save-a-lot&nbsp;Markets<span class="xml__tag_end">&lt;/CompanyName&gt;</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Country</span><span class="xml__tag_start">&gt;</span>USA<span class="xml__tag_end">&lt;/Country&gt;</span>&nbsp;<br>&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Customer&gt;</span>&nbsp;<br><span class="xml__tag_end">&lt;/Customers&gt;</span>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>[2] から始まる 2 行のクエリ式では、クエリ式の構文や標準クエリ演算子の使い方は、前回までに説明したものと同じです。最も大きな違いは、In キーワードの後に記述されたデータソースであり、XML データを表す専用のオブジェクトを使います。専用のオブジェクトには、主なものとして XDocument と XElement があります。</p>
<p>[2] の In キーワードの後ろで使用される変数 doc1 は [1] で定義されています。これは、メモリ上にロードされた XML ドキュメント全体に相当するもので、XDocument 型のオブジェクトです。[1] のようにファイル パスを指定し (ここでは、カレント ディレクトリの XMLFile1.xml を使用しています)、Load メソッドで読み込むことで、インスタンスが作成されます。</p>
<p>In キーワードの後ろでは、doc1 オブジェクトの Descendants メソッドを呼び出し、このドキュメントの各階層の中で、&quot;Customer&quot; という名前の要素ブロックすべてを取得しています。つまり、クエリ式の操作対象となるデータソースは、&lt;Customer&gt; 要素のコレクションです。</p>
<p>そして、[2] の変数 c は、&lt;Customer&gt; 要素 1 つを表す変数であり、1 つの要素は XElement 型オブジェクトに当たります。正確にいうと、XDocument オブジェクトも XElement オブジェクトも、子要素を含むことができるので、どちらも XML の階層構造 (XML ツリー) を表しています。ただし、XDocument オブジェクトのほうは、XML ファイルの 1 行目の XML 宣言 (Declaration プロパティ) を含むなど、ファイル全体を表します。</p>
<p>また Where 句では、XElement オブジェクト (変数 c) の Element メソッドを呼び出すことで、子要素 &lt;Country&gt; を参照しています。(もし、名前が重複する子要素が複数存在する場合は、子要素の中で最初に登場した要素を参照します。) この抽出条件では、子要素の値 (Value プロパティ) が、&quot;USA&quot; であるものを抽出します。さらに、Select 句がないので、クエリ結果は抽出した &lt;Customer&gt; 要素 (XElement オブジェクト) のコレクションです。</p>
<p>このように、クエリ式 1 つだけで、XML データを簡単に加工できます。もちろん、Select 句を使用すれば自由に整形できるので、XML データ以外の任意のデータに変換することもできます。</p>
<p style="margin-top:20px"><a href="#top"><img src="16922-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. LINQ to XML 対応の XML データのオブジェクト</h2>
<p>そもそも .NET Framework では、 XML データをメモリ上に表現するオブジェクトとして、W3C ドキュメント オブジェクト モデル (DOM) に対応した XmlDocument や XmlNode があります。一方 LINQ to XML では、前述のとおり、専用の XDocument や XElement を使用する必要があります。このように、XML データ向けのオブジェクト体系 (オブジェクトの種類など) が増えることになりますが、後者の使い方は分かりやすいので、すぐに慣れるでしょう。それに、この
 LINQ to XML 向けのオブジェクト モデルは、コード上で XML データを操作する際に、XML を簡潔に表現できる点で優れています。次に、この点を確認してみましょう。</p>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p><strong>Note</strong>: LINQ to XML と従来の DOM との違いは、以下のアドレスを参照してください。</p>
<ul>
<li><strong><a href="http://msdn.microsoft.com/ja-jp/library/bb387021" target="_blank">MSDN: LINQ to XML と DOM</a></strong>
</li></ul>
</div>
<p>XML データをアプリケーションで扱う場合、既存のファイルを扱うだけでなく、実行時にコード上で必要な XML データを動的に構築する場合もあるでしょう。特に、LINQ to XML のオブジェクト モデルでは、このような場合に、構築すべき XML データを簡潔に表現できます。次の例 2 の [1] から [2] では、2 つの &lt;Customer&gt; 要素を子要素として含む、&lt;Customers&gt; 要素を構築する例です。</p>
<p><strong>例 2. XElement を使用した簡潔な XML データの関数型構築</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;customers1&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XElement(<span class="visualBasic__string">&quot;Customers&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">1</span>]&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XElement(<span class="visualBasic__string">&quot;Customer&quot;</span>,&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XElement(<span class="visualBasic__string">&quot;CustomerID&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;ALFKI&quot;</span>),&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XElement(<span class="visualBasic__string">&quot;CompanyName&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Alfreds&nbsp;Futterkiste&quot;</span>),&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XElement(<span class="visualBasic__string">&quot;Country&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Germany&quot;</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;),&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XElement(<span class="visualBasic__string">&quot;Customer&quot;</span>,&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XElement(<span class="visualBasic__string">&quot;CustomerID&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;AROUT&quot;</span>),&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XElement(<span class="visualBasic__string">&quot;CompanyName&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Around&nbsp;the&nbsp;Horn&quot;</span>),&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XElement(<span class="visualBasic__string">&quot;Country&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;UK&quot;</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">2</span>]&nbsp;<br>&nbsp;&nbsp;<br><span class="visualBasic__keyword">Dim</span>&nbsp;query1&nbsp;=&nbsp;From&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;customers1.Elements(<span class="visualBasic__string">&quot;Customer&quot;</span>)&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">3</span>]&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Where&nbsp;c.Element(<span class="visualBasic__string">&quot;Country&quot;</span>).Value&nbsp;=&nbsp;<span class="visualBasic__string">&quot;UK&quot;</span>&nbsp;<br>&nbsp;&nbsp;<br><span class="visualBasic__keyword">Dim</span>&nbsp;doc1&nbsp;=&nbsp;XDocument.Load(<span class="visualBasic__string">&quot;XMLFile1.xml&quot;</span>)&nbsp;<br>doc1.Root.Add(customers1.Elements)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">4</span>]&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>この記述方法は、「関数型構築 (functional construction)」とも呼ばれています。「関数型構築」とは、単一のステートメントで XML ツリーを構築する記述方法です。この例では、変数 customers1 に対して、&lt;Customers&gt; 要素ブロックのデータを設定するために、必要な単一の XElement オブジェクトを作成しています。</p>
<p>特に注目すべき点は、記述そのものもが、XML データの階層構造をうまく表現している点です。これにより、構築対象の XML データの構造も把握しやすくなります。このように表記が出来るのも、XElement クラスのコンストラクタの引数として、上記のようにそのインスタンスの子要素を渡すことができるからです。ここでは簡単にするため、静的なコンテンツを作成していますが、通常の Visual Basic の構文で記述するので、必要に応じてコンストラクタの引数の一部に、式や変数を渡すことで、実行時の状況に応じた柔軟な
 XML 作成ができます。</p>
<p>もちろん、構築されたコンテンツは、[3] のようにクエリ式で利用できます。また、[4] のように XML ファイルから読み込んだ XML データ (XDocument オブジェクト) とマージすることもできます。</p>
<p style="margin-top:20px"><a href="#top"><img src="16923-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. XML リテラルを使用した簡潔な XML データ構築</h2>
<p>前述の関数型構築は、クラス ライブラリとして提供されているので、Visual Basic や C# など、.NET Framework 対応のプログラミング言語で利用できます。さらに Visual Basic では、上記の XElement オブジェクトを使用した関数型構築を「XML リテラル」を用いて、より簡潔に表現することができます。次の例 3 の [1] から [2] では、前述の例 2 の関数型構築を「XML リテラル」で書き換えたものです。</p>
<p><strong>例 3. XML リテラルによる XML データ構築</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;customers1&nbsp;=&nbsp;&lt;Cutomers&gt;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">1</span>]&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Customer&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CustomerID&gt;ALFKI&lt;/CustomerID&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CompanyName&gt;Alfreds&nbsp;Futterkiste&lt;/CompanyName&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Country&gt;Germany&lt;/Country&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Customer&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Customer&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CustomerID&gt;ABOURT&lt;/CustomerID&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CompanyName&gt;Around&nbsp;the&nbsp;Horn&lt;/CompanyName&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Country&gt;UK&lt;/Country&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Customer&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Cutomers&gt;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">2</span>]&nbsp;<br>&nbsp;&nbsp;<br><span class="visualBasic__keyword">Dim</span>&nbsp;query1&nbsp;=&nbsp;From&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;customers1.&lt;Customer&gt;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">3</span>]&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Where&nbsp;c.&lt;Country&gt;.Value&nbsp;=&nbsp;<span class="visualBasic__string">&quot;UK&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">4</span>]&nbsp;<br>&nbsp;&nbsp;<br><span class="visualBasic__keyword">Dim</span>&nbsp;doc1&nbsp;=&nbsp;XDocument.Load(<span class="visualBasic__string">&quot;XMLFile1.xml&quot;</span>)&nbsp;<br>doc1.Root.Add(customers1.&lt;Customer&gt;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">5</span>]&nbsp;<br><span class="visualBasic__keyword">Dim</span>&nbsp;query2&nbsp;=&nbsp;From&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;doc1...&lt;Customer&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">6</span>]&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;Company&nbsp;=&nbsp;c.&lt;CompanyName&gt;.Value,&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Country&nbsp;=&nbsp;c.&lt;Country&gt;.Value&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>この例 3 の [1] から [2] のように、XML データ自体をタグ形式で Visual Basic のコードの中に書くことができます。(こうした記述方法は、Visual Basic でしかできません。) Visual Basic のコンパイラは、これを XElement オブジェクトに展開します。</p>
<p>この「XML リテラル」では、DTD (Document Type Definition) が使用できないなど、一部制約はあるものの、XML 1.0 仕様とほぼ同様の構文が書けます。処理命令やコメントも書くことができます。</p>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p><strong>Note</strong>: XML リテラルと XML 1.0 との違いは以下のアドレスを参照してください。</p>
<ul>
<li><strong><a href="http://msdn.microsoft.com/ja-jp/library/bb384659" target="_blank">MSDN: XML リテラルと XML 1.0 仕様</a></strong>
</li></ul>
</div>
<p>結局のところ「XML リテラル」は XElement オブジェクトなので、例 3 の [3] のようにクエリ式で使用したり、[5] のように XDocument オブジェクトにマージしたりできます。</p>
<p>さらに「XML リテラル」という名前から静的なコンテンツと想像しがちですが、実は動的なコンテンツも記述できるのです(後述)。</p>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p><strong>Note:</strong> XML リテラルでは、XML 名前空間を表すプレフィックスも利用できます。詳しくは、以下を参照してください。</p>
<ul>
<li><strong><a href="http://msdn.microsoft.com/ja-jp/library/bb384655" target="_blank">MSDN: (方法) XML 名前空間プレフィックスを宣言して使用する</a></strong>
</li></ul>
</div>
<p style="margin-top:20px"><a href="#top"><img src="16924-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. XML 軸プロパティを使用した簡潔なアクセス</h2>
<p>上記の「XML リテラル」のほかにも Visual Basic には、LINQ to XML の XML データにアクセスするための、「XML 軸プロパティ」と呼ばれる簡易表現があります。例えば、例 3 の [3] の &quot;customers.&lt;Customer&gt;&quot; が XML 軸プロパティの表記方法の 1 つです。変数名の後にドットを付けて、タグ形式で子要素名を書くことができます。これは、単一の子要素ではなく、customers オブジェクトが持つ &lt;Customer&gt; 子要素すべてを表しています。</p>
<p>また [4] では同様に、&lt;Country&gt; という子要素の Value プロパティを参照しています。(例 1 の [2] のクエリ式における &quot;Country&quot; の参照と同様に、&lt;Country&gt; 子要素が複数存在する場合は、最初に登場した &lt;Country&gt; 子要素になります。)</p>
<p>最後に [6] の In キーワードの後ようにドットを 3 つ続けて要素名を書くと、その変数が表わす XML ツリーの中で、階層に関係なく、すべての該当する名前の要素の集合になります。つまり、例 1 の Descendants メソッドに相当します。</p>
<p>なお、この例にはありませんが、属性を参照する場合は、次のようにアットマークを使用します。</p>
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"> 変数名.@属性名</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p><strong>Note:</strong> 既定の環境構成では、変数名の後にドットを入力しても、要素名の候補が IntelliSense 機能によってリストアップすることはありません。しかし、プロジェクトに XML スキーマファイルを組み込むと、要素名もリストアップするようになります。詳しくは以下を参照してください。</p>
<ul>
<li><strong><a href="http://msdn.microsoft.com/ja-jp/library/bb531325" target="_blank">MSDN: Visual Basic における XML IntelliSense</a></strong>
</li></ul>
</div>
<p style="margin-top:20px"><a href="#top"><img src="16925-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="06">6. XML リテラルと埋め込み式を使用した動的な XML データ作成</h2>
<p>次に、XML リテラルを使用して、動的にコンテンツを作成する方法を見てみましょう。実は、XML リテラルには、次の例 4 ように Visual Basic の式を埋め込むことができます。これによって、XML リテラルの中に動的なコンテンツを組み込むことができます。</p>
<p><strong>例 4. XML リテラルと埋め込み式の使用</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p><br>
Dim db As New NorthwindDataContext()<br>
Dim customers1 = &lt;Cutomers&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Customer&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CustomerID&gt;ALFKI&lt;/CustomerID&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CompanyName&gt;Alfreds Futterkiste&lt;/CompanyName&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Country&gt;Germany&lt;/Country&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Customer&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="background-color:#ffff00">&lt;%</span>= From c In db.Customers Where c.Country = &quot;France&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select &lt;Customer&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CustomerID&gt;&lt;%= c.CustomerID %&gt;&lt;/CustomerID&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CompanyName&gt;&lt;%= c.CompanyName %&gt;&lt;/CompanyName&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Country&gt;&lt;%= c.Country %&gt;&lt;/Country&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Customer&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="background-color:#ffff00">&nbsp;%&gt;</span><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Cutomers&gt;</p>
</div>
<p>上記の例のように、黄色部分の &quot;<strong>&lt;%=</strong>&quot; から &quot;<strong>%&gt;</strong>&quot; で囲まれた部分に、Visual Basic の構文を使用して、何らかの値を返す式を書くことができます。ここでは、&lt;Customer&gt; 要素を書くべき場所に式を埋め込み、クエリ式を使用して、SQL Server の Customers テーブル (db.Customers) から、Country 列が &quot;France&quot; の行を抽出して追加しています。(クエリ式の
 In キーワードに記述された変数 db は、LINQ to SQL のオブジェクトです。LINQ to SQL については、<a href="http://beta.code.msdn.microsoft.com/25-LINQ-to-SQL-88fa685e">前回</a>を参照してください。)</p>
<p>さらに Select 句の中でも、&lt;Customer&gt; 要素になるように、XML リテラルを使用して整形しています。このように埋め込み式の中でも、XML リテラルが利用できます。さらに、子要素の &lt;CustomerID&gt; の値にも、埋め込み式を使い、Customers テーブルから抽出した行の値を設定しています。このように、埋め込み式のブロックは入れ子に出来る点にも注意してください。</p>
<p style="margin-top:20px"><a href="#top"><img src="16926-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="07">7. LINQ to XML による XML データ変換</h2>
<p>最後に 1 つ、今までの内容をふまえた応用例を見てみましょう。</p>
<p>次の例 5 の [1] では、LINQ to XML および Visual Basic の XML リテラルや埋め込み式を使用し、1 つのクエリ式だけを用いて、XSLT 変換でありがちな XML データの変換を行った例です。</p>
<p><strong>例 5. クエリ式 1 つで、XSLT 変換のような XML データの変換を行う</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;doc1&nbsp;=&nbsp;XDocument.Load(<span class="visualBasic__string">&quot;XMLFile1.xml&quot;</span>)&nbsp;<br>&nbsp;&nbsp;<br><span class="visualBasic__keyword">Dim</span>&nbsp;query1&nbsp;=&nbsp;From&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;doc1...&lt;Customer&gt;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[<span class="visualBasic__number">1</span>]&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;&lt;Customer&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerID=&lt;%=&nbsp;c.&lt;CustomerID&gt;.Value&nbsp;%&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName=&lt;%=&nbsp;c.&lt;CompanyName&gt;.Value&nbsp;%&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Country=&lt;%=&nbsp;c.&lt;Country&gt;.Value&nbsp;%&gt;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&gt;&nbsp;<br>&nbsp;&nbsp;<br>doc1.Root.ReplaceAll(query1)&nbsp;<br>doc1.Save(<span class="visualBasic__string">&quot;XMLFile2.xml&quot;</span>)&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>ここでは、&lt;Customer&gt; 要素の各子要素が、新しい &lt;Customer&gt; 要素の属性になるように変換しています。最終的に元の XMLFile1.xml は、次の示す XMLFile2.xml になります。</p>
<p><strong>例 6. 変換後の XMLFile2.xml</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb">&lt;?xml&nbsp;version=<span class="visualBasic__string">&quot;1.0&quot;</span>&nbsp;encoding=<span class="visualBasic__string">&quot;utf-8&quot;</span>?&gt;&nbsp;<br>&lt;Customers&gt;&nbsp;<br>&nbsp;&nbsp;&lt;Customer&nbsp;CustomerID=<span class="visualBasic__string">&quot;ERNSH&quot;</span>&nbsp;CompanyName=<span class="visualBasic__string">&quot;Ernst&nbsp;Handel&quot;</span>&nbsp;Country=<span class="visualBasic__string">&quot;USA&quot;</span>&nbsp;/&gt;&nbsp;<br>&nbsp;&nbsp;&lt;Customer&nbsp;CustomerID=<span class="visualBasic__string">&quot;QUICK&quot;</span>&nbsp;CompanyName=<span class="visualBasic__string">&quot;QUICK-Stop&quot;</span>&nbsp;Country=<span class="visualBasic__string">&quot;Germany&quot;</span>&nbsp;/&gt;&nbsp;<br>&nbsp;&nbsp;&lt;Customer&nbsp;CustomerID=<span class="visualBasic__string">&quot;SAVEA&quot;</span>&nbsp;CompanyName=<span class="visualBasic__string">&quot;Save-a-lot&nbsp;Markets&quot;</span>&nbsp;Country=<span class="visualBasic__string">&quot;USA&quot;</span>&nbsp;/&gt;&nbsp;<br>&lt;/Customers&gt;&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>例 5 の [1] から始まるクエリ式の Select 句では XML リテラルを使用して、変換後の XML データを直観的に分かる形式で表現できます。XML リテラルの埋め込み式には、クエリ式で対象としている &lt;Customer&gt; 要素 (変数 c) をそのまま使用しています。</p>
<p>こうした変換処理における従来の典型的な方法としては、XSLT 変換を行う方法が挙げられますが、この方法であれば、Visual Basic プログラマーは、馴染みのある Visual Basic の言語の知識の範囲内で、クエリ式 1 つを用いて簡潔に変換ルールを表現できます。しかも、XML リテラルを用いることで、変換結果を見た目のとおり表現でき、可読性も向上します。</p>
<p>LINQ to XML は XSTL の代用としての技術ではありませんが、状況に応じて上記のような使い方 (応用例) も可能であるということをおぼえておいてください。</p>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p><strong>Note:</strong> XSLT 変換など他の XML テクノロジと LINQ to XML との関係や位置づけは、以下のアドレスを参照してください。</p>
<ul>
<li><strong><a href="http://msdn.microsoft.com/ja-jp/library/bb387048" target="_blank">MSDN: LINQ to XML とその他の XML テクノロジ</a></strong>
</li></ul>
</div>
<p>以上、LINQ to XML と、それにまつわる Visual Basic 固有の表現について確認してきました。Visual Basic では、このように XML データをより効率よく扱う仕組みが用意されています。せっかくある機能なのですから、生産性や保守性の向上のためにもうまく活用してみてください。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank"><img src="-ff950935.netframework_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt=".NET Framework デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff357686" target="_blank">
連載! とことん Visual Basic 一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank">
Code Recipe へ</a> </li><li>もっと .NET Framework の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank">
.NET Framework デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
</div>
