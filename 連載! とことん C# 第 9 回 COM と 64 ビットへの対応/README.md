# 連載! とことん C#: 第 9 回 COM と 64 ビットへの対応
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2008
- Visual Studio 2010
## Topics
- C# プログラミング
- 連載 C#
## Updated
- 02/10/2011
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
<div>
<h4><span style="color:#000000; font-family:Verdana,Arial,Helvetica,sans-serif; font-weight:normal; line-height:normal">更新日: 2010 年 2 月 19 日</span></h4>
</div>
<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#kawamata" target="_blank">
株式会社ピーデー 川俣 晶</a></p>
<div style="margin:0; background-color:#d9e8ec; border:2px #46689a solid">
<div style="background-color:#d9e8ec; border:1px #ffffff solid">
<div style="padding:5px; font-size:100%; border:1px #46689a solid">
<p style="margin:0; padding:0">この記事は、「MSDN プログラミング シリーズ」として発行している技術書籍「<strong><a title="新しいウィンドウで開きます" href="http://www.amazon.co.jp/%E3%83%97%E3%83%AD%E3%83%95%E3%82%A7%E3%83%83%E3%82%B7%E3%83%A7%E3%83%8A%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC-Visual-C-2010-MSDN%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0%E3%82%B7%E3%83%AA%E3%83%BC%E3%82%BA/dp/4822294277/ref=sr_1_2?ie=UTF8&s=books&qid=1278660725&sr=8-2" target="_blank">プロフェッショナルマスター
 Visual C# 2010 ～最新テクニックをマスターする 35 のテーマ</a></strong>」(日経 BP 社刊) を基にワンポイント テクニックを紹介しています。</p>
</div>
</div>
</div>
<hr>
<table border="0" cellspacing="0" cellpadding="0" style="width:100%; margin-bottom:10px">
<tbody>
<tr>
<td valign="top" style="width:16%; padding:10px; border-bottom:#ffffff dotted 1px">
<strong>センセーション</strong></td>
<td valign="top" style="padding:10px; border-bottom:#ffffff dotted 1px">「おほん、教師のセンセーションである」</td>
</tr>
<tr>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px"><strong>ジョシュア</strong></td>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px">「生徒のジョシュアです。ところで、COM を使った昔のプログラムを呼び出さないといけなくなりました。Office もありますが、自前の COM サーバーもあるみたいです。これって C# から呼び出すと面倒ですか?」</td>
</tr>
<tr>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px"><strong>センセーション</strong></td>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px">「いやいや、簡単に呼び出せるのじゃよ。しかし、あくまで C# の世界と COM の世界は違う世界だから罠にも陥りやすいのじゃ。たとえば、64 ビット環境で動かないのはよくある話じゃ」</td>
</tr>
<tr>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px"><strong>ジョシュア</strong></td>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px">「ぜひ書き方を教えてください。それから 64 ビットの罠もお願いします。」</td>
</tr>
<tr>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px"><strong>センセーション</strong></td>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px">「よし、では罠の話は後回しにして、まずは簡単に Office を呼び出せる話からじゃ」</td>
</tr>
</tbody>
</table>
<hr>
<h2>目次</h2>
<ol>
<li><a href="#01">まずは、「参照渡し」の復習を...</a> </li><li><a href="#02">ref と COM</a> </li><li><a href="#03">64 ビットと .NET Framework</a> </li><li><a href="#04">64 ビットと COM</a> </li><li><a href="#05">結末</a> </li></ol>
<hr>
<h2 id="01">1. まずは、「参照渡し」の復習を...</h2>
<p>メソッド等を呼び出す場合の引数は、通常、値渡しとなっています。これは「値がメソッドに渡るだけで、それっきり縁が切れる」ことを意味します。つまり、メソッド内でいくら値を書き換えても、呼び出し元には何の影響もないことを意味します。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">using System;

class Program
{
    static void m(int x)
    {
        x = 456;
    }

    static void Main(string[] args)
    {
        int a = 123;
        m(a);
        Console.WriteLine(&quot;value is {0}&quot;, a);
    }
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p>実行結果:</p>
<p>value is 123</p>
</div>
<p>もし、メソッド内で行った変化を有効なものとしてメソッドを終えても残したい場合は、前回も述べたように、値渡しを参照渡しに変更します。そのためには、引数に ref キーワードを追加します。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">using System;

class Program
{
    static void m(ref int x)
    {
        x = 456;
    }

    static void Main(string[] args)
    {
        int a = 123;
        m(ref a);
        Console.WriteLine(&quot;value is {0}&quot;, a);
    }
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p>実行結果:</p>
<p>value is 456</p>
</div>
<p>渡されるのは「値型の変数に対する参照」になります。前回述べたように、値を受け取ることを明示する場合は、ref ではなく out を使うことができました。いずれにしても、呼び出される側と呼び出す側の双方にキーワードが必要です。</p>
<p style="margin-top:20px"><a href="#top"><img src="16783-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. ref と COM</h2>
<p>普通に C# でプログラムを書いていると、この参照渡しの出番は多くありません。しかし、Microsoft Office に属する Microsoft Excel や Microsoft Word などをプログラムで多用すると、即座に利用頻度が増えていく傾向にあります。なぜなら、ref 指定を要求する引数が多いからです。しかし、機能的に本当に ref 指定が必要とは限りません。</p>
<p>例えば、<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/Microsoft.Office.Interop.Word.Documents.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Word.Documents">Microsoft.Office.Interop.Word.Documents</a> クラス (Office 相互運用のための Microsoft.Office.Interop.Word.dll に含まれるクラスです) で、文書を開く Open メソッドは、以下のようなシグネチャです。このメソッドは、文書ファイルを Microsoft Word で開き、<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/Microsoft.Office.Interop.Word.Document.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Word.Document">Microsoft.Office.Interop.Word.Document</a> オブジェクトを返します。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">Open(ref object FileName, [ref object ConfirmConversions = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object ReadOnly = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object AddToRecentFiles = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object PasswordDocument = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object PasswordTemplate = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object Revert = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object WritePasswordDocument = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object WritePasswordTemplate = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object Format = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object Encoding = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object Visible = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object OpenAndRepair = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object DocumentDirection = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object NoEncodingDialog = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>], [ref object XMLTransform = <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Type.Missing.aspx" target="_blank" title="Auto generated link to System.Type.Missing">System.Type.Missing</a>])</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>見ての通り、膨大な引数が用意されていますが、Visual Studio 2010 の C# 4.0 であれば引数の省略と名前付きの指定を用いて、必要な項目だけ簡潔に記述できます。(これについては、<a href="http://msdn.microsoft.com/ja-jp/ff384145.aspx">第 6 回</a>を参照してください。) 読み取り専用 (ReadOnly) で、「最近使用したファイルへの追加」(AddToRecentFiles) の引数を指定して、所定のファイル名のファイルを開く場合、以下のようになります。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">using System;

class Program
{
    static void Main(string[] args)
    {
        object referTrue = true, referFalse = false;
        var word = new <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/Microsoft.Office.Interop.Word.Application.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Word.Application">Microsoft.Office.Interop.Word.Application</a>();
        object filename = @&quot;c:\sample.docx&quot;;
        word.Visible = true;
        word.Documents.Open(ref filename, ReadOnly: ref referTrue, AddToRecentFiles: ref referFalse);
    }
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>また、C# 4.0 では、Office に対する相互運用に限って、ref は省略することができます。つまり、以下のように記述しても構いません。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">word.Documents.Open(filename, ReadOnly: referTrue, AddToRecentFiles: referFalse);</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>もともと、参照扱いであればこそ値の受け渡しに「変数」(入れ物) が必要なのであって、上記のようなただの値渡しならば、この入れ物は必要ありません。つまり、以下のように簡潔な記述でも良いわけです。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>using System;</p>
<p>class Program<br>
{<br>
&nbsp;&nbsp;&nbsp;&nbsp;static void Main(string[] args)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var word = new <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/Microsoft.Office.Interop.Word.Application.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Word.Application">Microsoft.Office.Interop.Word.Application</a>();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;word.Visible = true;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;word.Documents.Open(@&quot;c:\sample.docx&quot;,
<strong>ReadOnly: true, AddToRecentFiles: false</strong>);<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
}</p>
</div>
<p>以上のように、C# 4.0 では、値渡しを基本とする C# の世界と、参照渡しを多用する従来からの COM の世界の垣根もさらに低くなり、C# のプログラムから Microsoft Word などの従来型ソフトを操作することも極めて容易になっています。しかし、いくら簡単に呼び出せるとはいえ、COM の世界は基本的に外部に存在する異質な世界です。ちょっとした拍子に、その差異が浮き彫りになることもります。その差異の一例として、つぎに 64 ビット環境で C# の世界と COM の世界の間にどのような問題が起きるか見てみることにしましょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="16784-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. 64 ビットと .NET Framework</h2>
<p>パソコンのオペレーティング システム (OS) にはいくつかの分類があります。その 1 つは、32 ビット環境か 64 ビット環境かという違いです。32 ビット環境の OS の多くは、4 GB のメモリ空間を提供しますが、これが手狭になってきたため 64 ビットへの移行が進んでいます。</p>
<p>C# では、この差をほとんど意識する必要がありません。なぜなら、C# でコンパイルされた実行ファイル (.dll ファイルや .exe ファイル) には、処理が中間言語 (IL) と呼ばれるプラットフォームに依存しない方式で記述されていて、実際に実行される機械語への翻訳は実行されるマシン上で行われるからです。そのマシンが 32 ビット環境であれば 32 ビット用の機械語が生成され、64 ビット環境であれば 64 ビット用に機械語が生成されるだけです。つまり、C# プログラマーは、&quot;一般的には&quot; 64 ビット環境への移行に際してほとんど意識することなく
 64 ビット対応を完了できます。</p>
<p>しかし、ごく一部の機能はビット数の差の影響を受けることに注意が必要です。例えば、以下のプログラムは 64 ビット環境では実行されますが、32 ビット環境では例外が起こります。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">using System;

class Program
{
    static void Main(string[] args)
    {
        IntPtr a = (IntPtr)0x123456789;
        Console.WriteLine(a);
    }
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>この理由は、IntPtr が、その環境 (32 ビット OS か、64 ビット OS か) のアドレス サイズによってビット数が変わるためです。そのため、両者の挙動は同じというわけではありません。</p>
<ul>
<li>64 ビット環境で確保できるメモリは、そのまま 32 ビット環境では確保できないかもしれない </li><li>IntPtr と内部で管理される参照 (アドレス) のサイズが違うため、64 ビットの方がよりメモリを消費する </li><li>実行速度も同じとは限らない </li></ul>
<p>しかし、これらが問題となるのはかなり特殊な状況であり、前述の通り、64 ビット対応のために既存のソース コードに手を入れる頻度は少なく、ほとんどの場合、無修正で動くのも事実でしょう。これが、C# の 1 つの魅力と言えるでしょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="16785-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. 64 ビットと COM</h2>
<p>しかし、書き換えずに自動的に 64 ビットに適応してくれる C# の魅力は、「外部の世界」と関わるとトラブルを引き起こしやすくなります。C# で書いたプログラムは、上記の通り、&quot;一般的には&quot; プラットフォームを意識せずに専用の機械語に翻訳してくれますが、32 ビットのネイティブ コードとして作成された実行ファイルは自動的には変化しません。その結果、C# で書いたプログラムが 64 ビットの空間上で実行され、32 ビットで作成したネイティブ コードのライブラリが呼び出せないなどのトラブルが生じることがあります。中でも、先ほどから例示している
 COM は注意が必要となります。</p>
<p>その理由は、64 ビットの Windows が持つ 32 ビット実行環境である WOW64 (Windows 32 on Windows 64) にあります。このシステム (WOW64) は、64 ビットの OS 上でも 32 ビットのアプリケーションが動作できるよう 64 ビットの Windows に搭載されていて、普段は意識することなく64 ビット アプリケーションと 32 ビット アプリケーションの双方を動作させることが可能です。しかし、別々のアプリケーションとして動作している場合は問題ありませんが、相互に連携をおこなう場合には注意が必要です。なぜなら、WOW64
 と言えども、同一プロセス内で、32 ビットと 64 ビットの混在は不可能だからです。このため、C# で書いたプログラムが 64 ビットの空間上で実行され、このプログラムが、あらかじめ 32 ビット アプリケーションとして作成 (コンパイル) されたネイティブ コードのライブラリ (例えば、外部のベンダーが作成したライブラリなど) を呼び出した場合に、呼び出せないなどのトラブルが発生することがあります。</p>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p><strong>Note:</strong> COM には、インプロセスとアウトプロセスという 2 通りの呼び出し方法があります。前者は .dll ファイルとして登録されている COM で、同一プロセス内で呼び出されます。一方後者は、.exe ファイルとして登録され、別のプロセスとして呼び出されます。このため、上述した問題は、前者のインプロセスの COM で発生することになります。(アウトプロセスの COM サーバーの呼び出しでは、マーシャリングと呼ばれる仕組みによって、プラットフォームに適合した方式に呼び出しなどが変換されます。)</p>
</div>
<p>また、WOW64 は、64 ビットのモジュールと 32 ビットのモジュールを厳&#26684;に分離して管理しており、相互に混ざらないようにしています。例えば、64 ビットの Windows 上では、64 ビット用の COM サーバーは通常通りレジストリの HKEY_CLASS_ROOT に登録されていますが、32 ビット用の COM サーバーは HKEY_CLASS_ROOT\Wow6432Node に登録されています。そのため、正常に登録され、正常に動作する COM サーバーが C# など .NET Framework
 を使用したアプリや、64 ビット専用アプリから見つからないという現象も起こる場合があるでしょう。</p>
<p>こうした場合の解決方法はいくつかあります。理想的には、呼び出すライブラリや COM サーバーの 64 ビット版があれば良いことになります。しかし、外部ベンダーが提供するライブラリなどで、それが手に入らない場合は、C# のプログラム自身を (64 ビットの OS 上でも) 32 ビット アプリケーションとして実行させることで、64 ビット環境であってもこうしたライブラリを呼び出せるようにします。方法は簡単で、プロジェクトのプロパティから [ビルド] タブのプラットフォーム ターゲットを「x86」に変更します
 (下図)。</p>
<p><img src="16786-image.png" border="0" alt="図"></p>
<p><strong>図: プラットフォーム ターゲットの変更 (Visual Studio 2010 の場合)</strong></p>
<p>上図で表示されている各プラットフォーム ターゲットのそれぞれの意味は以下のようになります。</p>
<table class="grid" border="1" cellspacing="0" cellpadding="5" style="border-collapse:collapse; margin-bottom:10px">
<tbody>
<tr>
<td valign="top">Any CPU</td>
<td>環境の種類は問わず、実行時にプラットフォームにあわせた実行イメージを作成して実行する。(初期値はこれ)</td>
</tr>
<tr style="background-color:#eff3f7">
<td>x86</td>
<td>x86 アーキテクチャの 32 ビット専用</td>
</tr>
<tr>
<td>x64</td>
<td>x64 アーキテクチャの 64 ビット専用</td>
</tr>
<tr style="background-color:#eff3f7">
<td>Itanium</td>
<td>Itanium アーキテクチャの 64 ビット専用</td>
</tr>
</tbody>
</table>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p><strong>Note:</strong> なお、.NET Framework では、パフォーマンスの最適化などの目的で、ネイティブ イメージ ジェネレーター (ngen) と呼ばれるユーティリティを使って、あらかじめ x86 用、x64 用などのネイティブ イメージとしてマシン上にアセンブリ (.dll や .exe) を登録することができます。(.NET Framework が既定でインストールしている多くのアセンブリは、この ngen によって登録されています。) 外部のライブラリを使用したアプリケーションの環境移行などの際には、こうした場合も考慮し、「どのモジュールが、どのような状態で呼び出されるか」といった点に留意しておく必要があるでしょう。</p>
</div>
<p style="margin-top:20px"><a href="#top"><img src="16787-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. 結末</h2>
<table border="0" cellspacing="0" cellpadding="0" style="width:100%; margin-bottom:10px">
<tbody>
<tr>
<td valign="top" style="width:16%; border-bottom:#ffffff dotted 1px; padding:10px">
<strong>ジョシュア</strong></td>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px">「分かりました! つまり、何もしなくても 64 ビットで動作するのが .NET の仮想マシンのメリットではあるけれど、それでは 32 ビットのモジュールとの相互運用性が失われることもあるのですね!」</td>
</tr>
<tr>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px"><strong>センセーション</strong></td>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px">「うむ。そのために、64 ビット OS であっても 32 ビットの仮想マシンで実行するオプションが用意されておる」</td>
</tr>
<tr>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px"><strong>ジョシュア</strong></td>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px">「ありがとうございます。これでプログラムが書けます!」</td>
</tr>
<tr>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px"><strong>センセーション</strong></td>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px">「あと COM サーバー、特に Office 関係のアセンブリも容易に呼び出せるが、64 ビット環境での動作確認も忘れるでないぞ」</td>
</tr>
<tr>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px"><strong>ジョシュア</strong></td>
<td valign="top" style="border-bottom:#ffffff dotted 1px; padding:10px">「はい! 簡単だからと言って油断してはいけないわけですね!」</td>
</tr>
</tbody>
</table>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank"><img title="Code Recipe" src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank"><img title=".NET Framework デベロッパー センター" src="-ff950935.netframework_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff357685" target="_blank">
連載! とことん Visual C# 一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっと .NET Framework の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank">
.NET Framework デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
</div>
