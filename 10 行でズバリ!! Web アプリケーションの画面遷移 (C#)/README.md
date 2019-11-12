# 10 行でズバリ!! Web アプリケーションの画面遷移 (C#)
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Visual Studio 2005
## Topics
- 10 行でズバリ!!
- Web アプリケーション
## Updated
- 02/16/2011
## Description
<style><!-- ﻿.showRatings{border-bottom:silver 1px solid;background-color:#f0f0f0;text-align:left;width:100%;height:28px;vertical-align:bottom;}.showRatings_right{z-index:99;float:right;} ﻿.CodeHighlighter{word-wrap:break-word;}pre{white-space:pre-wrap;white-space:-moz-pre-wrap;white-space:o-pre-wrap;}
 ﻿.VCR_Container{position:relative;}.VCR_GroupLabel{color:#333;font-weight:bold;padding:5px 0 1px;}.VCR_GroupLabel:first-child{padding-top:0;}.VCR_Label{border-left:1px solid #fff;border-bottom:1px solid #fff;color:#06d;cursor:pointer;margin:2px 0 0 0;padding:1px
 0 2px 4px;}.VCR_Label_Focussed{background:#e3e3e3 url('../../images/common.png') 0 -74px repeat-x;border-left:1px solid #c2c2c2;border-bottom:1px solid #c2c2c2;color:#f60;}.VCR_Label_Selected{background:#e3e3e3 url('../../images/common.png') 0 -74px repeat-x;border-left:1px
 solid #c2c2c2;border-bottom:1px solid #c2c2c2;}.VCR_ContentItem{background-color:#fff;display:none;padding-left:12px;overflow:hidden;position:absolute;top:0;right:0;bottom:0;left:0;}.VCR_CheckBox{cursor:pointer;position:absolute;top:0;right:4px;}.VCR_CheckBoxImage{background:#260859
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
 div.ItemCont{background:#f3f3f7;margin-bottom:25px;margin-right:29px;float:left;}div.HeadlineNews a.Item{display:inline-block;overflow:hidden;margin-bottom:5px;}div.HeadlineNews h2.NewsTitle{padding:0 0 10px 4px;font-weight:100;}div.HeadlineNews h2.NewsTitle
 span.Last{font-family:"Segoe UI Light","Segoe UI","Lucida Grande",Verdana,Arial,Helvetica,sans-serif;font-weight:200;}div.HeadlineNews span.Image{display:block;overflow:hidden;margin-bottom:6px;}div.HeadlineNews span.Title{display:block;padding:5px 5px 6px
 5px;font-size:120%;}div.HeadlineNews span.Description,div.HeadlineNews span.Description:hover,div.HeadlineNews span.Description:active{display:block;padding:0 5px 4px 5px;color:#000;line-height:16px;}div.HeadlineList{display:inline-block;margin-bottom:10px;}div.HeadlineList
 div.Items{display:inline-block;}div.HeadlineList div.ItemsWithHeaderImage{padding:13px 21px 0 13px;}div.HeadlineList a.Item{width:100%;}div.HeadlineList a.Item span{display:inline-block;}div.HeadlineList div.Items .ShareThis2Cont{margin-bottom:20px;}div.HeadlineList
 div.Items .ShareThis2{float:right;position:relative;top:-4px;}div.HeadlineList a.Item .Description,div.HeadlineList a.Item span.Description:hover,div.HeadlineList a.Item span.Description:active{display:inline-block;color:#000;margin-bottom:10px;}div.HeadlineNews
 div.ItemCont{margin-bottom:25px;margin-right:20px;}div.HeadlineNews{margin-right:0;}div.HeadlineViewer div.Controls div.RightControls a.ControlRss span.Icon,div.HeadlineNews a.ControlRss span.Icon{top:-3px;left:16px;}div.HeadlineList div.Items .ShareThis2{float:right;position:relative;top:0;}.FooterLinks{padding:6px
 0 12px 8px;}.FooterLinks A{color:#03c;font-weight:normal;}A.FooterLinks:hover{color:#f60;}.FooterCopyright{color:#333;font-weight:normal;padding-right:8px;}.Pipe{color:#000;font-size:125%;padding:0 4px;}.FeedViewerBasicIdentification{display:none;}.MtpsFeedViewerBasicRootPanelClass{clear:left;margin:0
 5px 5px 0;padding:0 5px 5px 0;vertical-align:top;width:auto;}.MtpsFeedViewerBasicHeaderStylePanel{vertical-align:middle;margin-bottom:10px;}.FVB_HeaderStyle_One,.FVB_HeaderStyle_Two,.FVB_HeaderStyle_Three,.FVB_HeaderStyle_Four,.FVB_HeaderStyle_Five{font-weight:900;}.FVB_HeaderStyle_One{font-size:200%;}.FVB_HeaderStyle_Two{font-size:175%;}.FVB_HeaderStyle_Three{font-size:150%;}.FVB_HeaderStyle_Four{font-size:125%;}.FVB_HeaderStyle_Five{font-size:100%;}A.TitleRSSButtonCssClass{vertical-align:middle;}A.TitleRSSButtonCssClass
 img{margin:0 0 0 5px;}.BasicHeadlinesItemPanelCssClass{float:left;margin-bottom:10px;padding:0 1% 0 0;vertical-align:top;}.BasicListItemPanelCssClass{float:left;margin-bottom:15px;padding:0 0 0 1%;vertical-align:top;}.FeedViewerBasicBulletListLI{padding-bottom:3px;}.FeatureHeadlinesTitle{margin-top:0;padding-top:0;vertical-align:top;}.TitleBold{font-weight:700;}.FeaturedHeadlinesItemPanelCssClass{float:left;padding:0
 1% 0 0;vertical-align:top;}.ImageHeadlineTabelCell{padding:0 5px 0 0;text-align:left;vertical-align:top;width:1%;}.ImageHeadlineTabelCell A IMG{border:solid 0 transparent;}.FeaturedRssItemTableCell{vertical-align:top;padding-bottom:12px;text-align:left;}.FVBAuthorLabel{font-weight:900;color:#555;font-size:smaller;padding:0
 5px 0 0;}.FVBPubDateLabel{font-style:italic;color:#555;font-size:smaller;}.FVB_ImageHeadlinesDiv{margin-bottom:10px;vertical-align:top;}.LimitedListItemPanelCssClass{float:left;vertical-align:top;margin-bottom:15px;padding:0 1% 0 0;}.ItemDiv{float:left;padding:0
 1% 0 0;}.ColumnDiv{clear:both;margin-top:15px;}.OverflowAuto{overflow:auto;}.OPMLImgDiv{float:left;margin-bottom:12px;padding:3px 10px 9px 0;}.OPMLTextDiv{vertical-align:top;min-height:30px;margin:0 0 12px 65px;}.OPMLFriendlyName{font-size:small;font-weight:bold;}.OPMLSubtitle{font-size:small;font-weight:normal;}.OPMLFriend{text-decoration:none;color:#555;}.FVBForumListLI{margin-bottom:10px;}.FVBForumDescriptionCssClass{width:auto;vertical-align:top;margin-bottom:15px;}.ListColumnPanel{float:left;padding-right:1%;}.EmptyPanel{clear:both;}.ListPanelMarginTop{margin-top:15px;}.TitleHidden{display:none;}.FR_Thumb
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
 .h3,.columnfifty .h3{background-color:#e8e8e8!important;}.top1,.boxheader{background:#e8e8e8;color:#260859!important;}.boxcontent{border-bottom:1px solid #e8e8e8!important;border-left:1px solid #e8e8e8!important;border-right:1px solid #e8e8e8!important;} body{font-family:Verdana,Arial,Helvetica,sans-serif;color:#000;font-size:68.75%}a{text-decoration:none;color:#03c}a:link{color:#03c}a:visited{color:#800080}a:hover{color:#f60}a:active{color:#800080}a
 img{border:none}H1{font-size:210%;font-weight:400}H1.heading{font-size:120%;font-family:Verdana,Arial,Helvetica,sans-serif;font-weight:bold;line-height:120%}H2{font-size:115%;font-weight:700}H2.subtitle{font-size:180%;font-weight:400;margin-bottom:.6em}H3{font-size:110%;font-weight:700}H4,H5,H6{font-size:100%;font-weight:700}h4.subHeading{font-size:100%}dl{margin:0
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
<p>最終更新日 2005 年 8 月 15 日</p>
<h2><img src="13481-image.png" alt=""> このコンテンツのポイント</h2>
<ul>
<li>4 つのパターンの Web アプリケーションの画面遷移方法と、その違いを理解する </li></ul>
<h2><img src="13482-image.png" alt=""> 今回紹介するコード</h2>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">// 画面遷移前の Web フォーム
protected void Button1_Click(object sender, EventArgs e)
{
    Response.Redirect(&quot;~/Page2.aspx&quot;);
}
protected void Button2_Click(object sender, EventArgs e)
{
    Server.Transfer(&quot;~/Page2.aspx&quot;);
}

// 画面遷移後の Web フォーム
protected void Page_Load(object sender, EventArgs e)
{
    if (Page.PreviousPage != null)
    {
        TextBox text1 = (TextBox) Page.PreviousPage.FindControl(&quot;TextBox1&quot;);
        if (text1 != null)
             TextBox1.Text = text1.Text;
    }
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<h3><img src="13483-image.png" alt=""> 今回のシステム要件</h3>
<ul>
<li>Visual Studio 2005 Beta 2 </li></ul>
<p>&nbsp;</p>
<h3>目次</h3>
<p><a href="#webapp_sc_cs1">はじめに</a><br>
<a href="#webapp_sc_cs2">作成するアプリケーションの概要</a><br>
<a href="#webapp_sc_cs3">Web アプリケーションの画面作成</a><br>
<a href="#webapp_sc_cs4">画面遷移の実装</a><br>
<a href="#webapp_sc_cs5">動作と解説</a><br>
<a href="#webapp_sc_cs6">おわりに</a></p>
<table cellpadding="5" bgcolor="#e5f1f8">
<tbody>
<tr>
<td colspan="2">Visual Basic の内容はこちらに掲載しています。</td>
</tr>
<tr>
<td align="center"><img src="13484-image.png" alt=""></td>
<td><a href="http://msdn.microsoft.com/ja-jp/netframework/a31a090b-1bb9-478b-bdc7-a7d3e441696f">10 行でズバリ!! Web アプリケーションの画面遷移 (VB)</a></td>
</tr>
</tbody>
</table>
<hr>
<h2 id="webapp_sc_cs1">はじめに</h2>
<p>.NET において Web アプリケーションを作成する場合、 ASP.NET が提供する 「Web フォーム」 を使用します。</p>
<p>Web フォームは、Web アプリケーションにおけるユーザー インターフェイスを構築するためのテクノロジーです。Web フォームでは、ユーザーのブラウザ上に、HTML ベースの Web ページとしてユーザー インターフェイスは表示されますが、そのWeb ページに関わる処理は、サーバーサイドで行われます。たとえば、ブラウザ上でユーザーがボタンをクリックした場合、そのことがサーバーに通知され、サーバー上に実装された Click イベントに呼応するイベント ハンドラが実行されます。</p>
<p>ネットワーク上の動作の観点から見ると、ユーザーがブラウザ上でボタンをクリックした場合、HTTP POST を使って、ページ上のデータがサーバーへポスト (投函) されます。原則として、このときポストに使用するアクセス先の URLは、現在表示しているページ自身の URL であり、自分自身にポストしています。その結果、自分自身のページに実装されたイベント ハンドラが呼び出されます。このような自分自身のページに対するポストを、「ポストバック」と呼びます。</p>
<p>この動作は、Windows フォームに&#20284;ています。Windows フォームでは、フォーム上のボタンがクリックされたとき、フォーム自身に実装されたイベント ハンドラが呼び出されます。そのため、Web フォームのプログラミング モデルは、Windows フォームのプログラマーにも馴染みやすいと言えます。</p>
<p>ここでは、このようなポストバックの仕組みもふまえ、ASP.NET での Web ページ間の遷移方法について説明します。</p>
<h2 id="webapp_sc_cs2">作成するアプリケーションの概要</h2>
<p>ここでは、ASP.NET における画面遷移について、主な 4 つの方法について取り上げます。画面遷移の基本的な仕組みを理解するのが目的なので、画面間でのデータの受け渡し方法の詳細は、割愛します。画面間のデータの受け渡し方法については、「<a href="http://msdn.microsoft.com/ja-jp/netframework/f8f75dfd-1064-4038-b0c9-163bb2c4dd44">10 行でズバリ !! ページ間におけるデータ受け渡し (C#)</a>」 を参照してください。</p>
<p>この後のアプリケーションには、以下の 4 つの画面遷移方法を実装します。</p>
<ul>
<li>HyperLink コントロールを使用して、リンクを行う </li><li>ポストバック先のサーバー サイドで、Response.Redirect メソッドを呼び出す </li><li>ポストバック先のサーバー サイドで、Server.Transfer メソッドを呼び出す </li><li>Button コントロールのポスト先が、別のページになるように設定する (Cross-Page Posting) </li></ul>
<p>なお、Web アプリケーションの基本的な作成方法は、「<a href="http://msdn.microsoft.com/ja-jp/netframework/f80edada-5bc0-43a6-8d8a-026e304858dc">10 行でズバリ!! ASP.NET Web フォームによる Web アプリケーション開発 (C#)</a>」 を参照してください。</p>
<h2 id="webapp_sc_cs3">Web アプリケーションの画面作成</h2>
<p>まず、新規に Web サイトを作成します。Visual Studio 2005 の [ファイル] メニューをクリックし、[新規作成] をポイントして、[Web サイト] をクリックします。 すると、[新しい Web サイト] ダイアログボックスが表示されます。</p>
<p>ここでは、言語として Visual C# を選択し、テンプレートとして 「ASP.NET Web サイト」 を選択します。 [場所] 欄では、ドロップダウン リストで 「ファイル システム」が選択されていることを確認した後、任意のパスを指定して (たとえば、 「C:\Test\Website1」 など)を入力し (図 1)、[OK] をクリックします。</p>
<p><img src="13485-image.png" alt=""></p>
<p><strong>図 1. Web サイトを新規に作成する</strong></p>
<p>これで、Web フォームによる Web ページ開発の準備として、雛形となる Web サイトができました。</p>
<p>既定の構成では、Default.aspx の編集画面としてソース ビューが開いているので、編集画面の左下部にある [デザイン] タブをクリックして、Web ページのデザイン画面に切り替えます。このデザイン画面で、画面レイアウトが図2になるように、ツールボックスの[標準] タブから、順にTextBox コントロール1 つ、HyperLink コントロール1 つ、および、Button コントロール 3 つを、ドラッグ アンド ドロップして貼り付けます。各コントロールが行ごとに分かれるよう、コントロール間で改行してください。また、図
 2 と見た目が同じになるよう、各コントロールの Text プロパティを変更します。なお、簡単にするため、各コントロールの ID は既定のままにしておきます。</p>
<p><img src="13486-image.png" alt=""></p>
<p><strong>図 2. 1 つ目の画面を作成する</strong></p>
<p>次に、画面遷移を行った際の遷移後の Web ページを追加します。</p>
<p>ソリューション エクスプローラのツリー上の、Web サイトのノード (今回の例では C:\Test\WebSite1) を右クリックして、[新しい項目の追加] メニューをクリックします。[新しい項目の追加] ダイアログボックスが表示されるので、テンプレートとして [Web フォーム] を選択し、[名前] ボックスには 「Page2.aspx」 と入力します (図 3)。ほかは既定のままにして、[追加] ボタンをクリックします。</p>
<p><img src="13487-image.png" alt=""></p>
<p><strong>図 3. 新しい Web ページ (Web フォーム) を追加する</strong></p>
<p>Page2.aspx のソース ビューが表示されるので、編集画面の左下にある [デザイン] タブをクリックして、デザイン ビューに切り替えます。図 4 のように、「2 番目のページ」という文字列を直接入力し、その下の行に TextBox コントロールを 1 つ貼り付けます。</p>
<p><img src="13488-image.png" alt=""></p>
<p><strong>図 4. 2 番目の Web ページ (Web フォーム) の画面を作成する</strong></p>
<p>画面が完成したら、[ファイル] メニューの [すべてを保存] をクリックして、保存しておきます。</p>
<h2 id="webapp_sc_cs4">画面遷移の実装</h2>
<p>次に、1 つ目の画面に 4つの画面遷移方法を実装します。ここで、Default.aspx のデザイン ビューに切り替えます。</p>
<p>まずは、HyperLink コントロールです。このコントロールでは、遷移先の Web ページの URL をプロパティに指定します。デザイン ビュー上の HyperLink コントロールをクリックし、プロパティ ウィンドウで NavigateUrl プロパティに 「~/Page2.aspx」 と入力します (図 5)。このコントロールは、Web ブラウザ上では、通常のリンクとして動作します。なお、チルダ「~」は、この Web アプリケーションのルート フォルダを意味します。</p>
<p><img src="13489-image.png" alt=""></p>
<p><strong>図 5. NavigateUrl プロパティを設定する</strong></p>
<p>次に、画面上に配置された一つ目の Button コントロールをブルクリックします。すると、Default.aspx.cs のコード エディタが開き、Click イベント ハンドラが生成されます。さらに、Default.aspx のデザイン ビューに切り替えて、2 つ目の Button コントロールもダブルクリックします。二つ目のイベント ハンドラが生成され、再びコード エディタが開きます。(イベント ハンドラを作成するのは、二つ目のボタンまでです。) ここで、各イベント ハンドラに次のコードを入力します。このコードでは、ページ上でクリックされた後、同じページに対してポストバックし、サーバーのコードで、ページの遷移
 を行っています。ASP.NET では、サーバー サイドのコードで画面遷移をするとき、この例で示すように 2 つの方法があります。それぞれのメソッドの意味は、動作確認の中で説明します。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">protected void Button1_Click(object sender, EventArgs e)
{
    Response.Redirect(&quot;~/Page2.aspx&quot;);
}
protected void Button2_Click(object sender, EventArgs e)
{
    Server.Transfer(&quot;~/Page2.aspx&quot;);
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>3つ目のボタンには、ポストバックを使わずに、別のページへポストする方法を実装します。</p>
<p>ここで、Default.aspx のデザイン ビューに戻り、3 つめのボタンを選択します。プロパティ ウィンドウで PostBackUrl プロパティに、「~/Page2.aspx」 と入力します (図 6)。この設定によって、自分自身のページにポストバックせずに、別のページにポストすることができます。</p>
<p><img src="13490-image.png" alt=""></p>
<p><strong>図 6. PostBackUrl プロパティを設定する</strong></p>
<p>最後に画面遷移後の画面にも、一部コードを追加しておきます。Page2.aspx のデザイン ビューに切り替えて、デザイン ビューの余白をダブルクリックします。すると、Page2.aspx.cs のコード エディタが開き、Page2.aspx の初期処理を行う Load イベント ハンドラが表示されます。</p>
<p>このイベント ハンドラでは、次のコードを入力します。このコードでは、遷移前の画面 Default.aspx のテキストボックス Textbox1 の内容を、遷移後の Page2.aspx のテキスト ボックス TextBox1 に代入しています。ASP.NET では、Web ページは Page オブジェクト (厳密には Page 派生クラスのオブジェクト) として扱われます。画面遷移の方法によっては、遷移後の画面のコードから、遷移前の Page オブジェクトにアクセスできます。メソッド内の if 文に含まれる
 Page.PreviousPage という記述では、「Page」 はフォーム自身のプロパティで現在アクティブな Page オブジェクトを表しています。その Page オブジェクトの PreviousPage プロパティは、遷移前の Page オブジェクトを表しています。if 文のブロック内では、FindControl メソッドを呼び出して、遷移前の画面のテキストボックスを参照しています。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">protected void Page_Load(object sender, EventArgs e)
{
    if (Page.PreviousPage != null)
    {
        TextBox text1 = (TextBox) Page.PreviousPage.FindControl(&quot;TextBox1&quot;);
        if (text1 != null)
             TextBox1.Text = text1.Text;
    }
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>コードが完成したら、[ファイル] メニューの [すべてを保存] をクリックして、保存しておきます。</p>
<h2 id="webapp_sc_cs5">動作と解説</h2>
<p>コードも画面も完成しましたので、実行してみます。まず、ソリューション エクスプローラ上で、Default.aspx を1回クリックして、選択された状態にします。次に、[Ctrl&#43;F5] キーを押すか、[デバッグ] メニューの [デバッグなしで開始] をクリックします。</p>
<p>すると、Visual Studio 2005 の既定の構成では、試験用の Web サーバーとして 「ASP.NET 開発サーバー」が自動的に起動し、そのサーバーの上で、Web アプリケーションが実行されるようになります。また、Web ブラウザが自動的に起動して、作成した Web ページが表示されます。URL には、ASP.NET 開発サーバーが使用するための、ランダムに設定されたポート番号が含まれています。このポート番号はソリューション ファイルに書き込まれ、これ以降は同じポート番号で実行することになります。</p>
<p>ブラウザには、Default.aspx が表示されるので、テキストボックスに任意の文字列、たとえば 「Hello, ASP.NET!」 と入力します (図 7)。</p>
<p><img src="13491-image.png" alt=""></p>
<p><strong>図 7. Default.aspx がブラウザに表示されるので、テキストボックスに入力する</strong></p>
<p>ここで、4 つの画面遷移の方法を確認します。</p>
<p>まずは、HyperLink コントロールを使用した、Page2 へのリンクです。これは単純なリンクであり、サーバーはブラウザに対して、単なる &lt;A href=&quot;Page2.aspx&quot;&gt; というタグとして送信しています。そのため、ブラウザ上でユーザーがリンクをクリックすると、HTTP GETを使用して、Page2.aspx を直接アクセスします。</p>
<p>ここで、リンクをクリックしてみましょう。すると、Page2.aspx に遷移します。ブラウザの URL欄も Page2.aspx になっているはずです。しかし、Page2.aspx では遷移前のテキストボックスを参照するようにコードを実装していたにも関わらず、Page2.aspx には遷移前のテキストボックスの内容は反映されていません (図 8)。リンクのように、単に HTTP 要求でページを遷移する場合、ASP.NET は遷移前の画面を認識できないからです。</p>
<p><img src="13492-image.png" alt=""></p>
<p><strong>図 8. リンクを使って次の画面に遷移する</strong></p>
<p>リンクを使う場合、データの受け渡しには、相応の仕組みが必要です。しかし、単にメニューから別の画面に分岐するなど、複雑なデータの受け渡しを伴わないなら、この方法が最も簡単です。また、.aspx ファイルに単に &lt;A&gt; タグとしてハードコーディングする方法ありますが、HyperLink コントロールを使えば、このページを表示する前に、サーバーサイドでプログラム内から NavigateUrl を設定でき、リンク先を柔軟に指定することができます。</p>
<p>なお、画面間のデータの受け渡しは、「<a href="http://msdn.microsoft.com/ja-jp/netframework/f8f75dfd-1064-4038-b0c9-163bb2c4dd44"> 10 行でズバリ !! ページ間におけるデータ受け渡し (C#)</a>」 を参照してください。</p>
<p>ここで、ブラウザの [戻る] ボタンを押して、Default.aspx (図 7) に戻ります。今度は、1 つ目のボタン [Response.Redirect] をクリックします。すると、Page2.aspx が表示され、リンクの場合と同様に、図 8 のようになります。URL 欄も Page2.aspx に変わります。</p>
<p>このボタンをクリックすると、Default.aspx 自身に対してポストバックを行い、Default.aspx の Click イベント ハンドラ内で、Response.Redirect メソッドを呼び出しています。これは、一般に 「リダイレクト」と呼ばれる方法に相等し、Redirect メソッドが呼びされた際に、Web サーバーはブラウザに対して、遷移後のページにアクセスするよう指示し、ブラウザは改めて、HTTP GET を使って Page2.aspx を要求しています。つまり、ネットワーク上は、HTTP要求/応答が、2
 往復することになります。</p>
<p>結果的には、リンクをクリックしたのと同様に、Page2.aspx に遷移します。そのため、ASP.NET は遷移前のページを認識できず、遷移後のテキストボックスに値は反映されません。</p>
<p>前述のリンクと、このリダイレクトとの方法と大きな違いの 1 つは、ユーザーによってポストされたデータの入力検&#35388;が、遷移する前に、サーバー側で可能か否かという点です。リダイレクトを使う方法では、データが不正 で画面の遷移をしたくなければ、Redirect メソッドを呼び出さなければよいのです。その場合、元の Default.aspx が再表示されます。前者のリンクでは、値の検&#35388;はせずに、無条件で画面遷移してしまいます。</p>
<p>ここで、ブラウザの [戻る] ボタンを押して、Default.aspx (図 7) に戻ります。今度は、2 つ目のボタン [Server.Transfer] をクリックします。</p>
<p>今回も、一旦、ポストバックを行い、Default.aspx の Click イベント ハンドラが呼び出されます。Click イベント ハンドラでは、Server.Transfer メソッドを呼び出します。このメソッドが呼び出されると、ASP.NET の実行環境内で、ページの遷移を行います。この場合、ASP.NET は画面遷移を認識でき、遷移前の Page オブジェクトにアクセスできるので、遷移後の画面のテキストボックスには、本来のコード実装のとおりに、遷移前の値が反映されています (図 9)。</p>
<p>また、Transfer メソッドを使う方法では、リダイレクトとは異なり、ブラウザは Default.aspx へ単にポストバックするだけで、ブラウザ側では画面遷移を行っていません。そのため、ブラウザには Default.aspx へのポストバックの結果として、Page2.aspx の内容が表示されます。その結果、図 9 のブラウザの URL 欄は、Default.aspx のままです。</p>
<p>Transfer メソッドを使う方法では、ASP.NET が画面遷移を認識できますが、ブラウザは遷移前の URL として認識しているので、ブラウザによっては、[戻る] ボタンを押してURL の履歴をたどると、誤動作する可能性があります。</p>
<p>なお、この方法でも、リダイレクトと同様に、遷移前にポストされたデータの検&#35388;を行うことができます。</p>
<p><img src="13493-image.png" alt=""></p>
<p><strong>図 9. Transfer を使って次の画面に遷移すると、アドレスは変わらない</strong></p>
<p>ここで、ブラウザの [戻る] ボタンを押して、Default.aspx (図 7) に戻ります。今度は、3 つ目のボタン [Cross-Page Posting] をクリックします。すると、Page2.aspx に遷移します (図 10)。今までの画面遷移と、若干の違いがあります。</p>
<p><img src="13494-image.png" alt=""></p>
<p><strong>図 10. ページをまたいで、ポストを行う</strong></p>
<p>この方法は、「Cross-Page Posting」 と呼ばれるもので、ASP.NET 2.0 から導入された新しい方法です。この方法では、自分自身にポストバックせずに、遷移後のページに直接ポストします。ポスト先は、先に指定した PostBackUrl プロパティのアドレスであり、今回は Page2.aspx に直接ポストします。</p>
<p>そのため、この方法では URL 欄は遷移後のアドレスです。また、この仕組みでは、ASP.NET 2.0 が遷移前のページを Page オブジェクトとして認識できるので、遷移前のテキストボックスの内容が、遷移後のテキストボックスに反映できます。</p>
<p>この明示的にポスト先を指定する方法は、1 つの Web ページの中を、論理的な複数の画面に分割して、分割された画面ごとに、ポスト先を変えたい場合に便利です。</p>
<p>なお、Transfer では、同一 Web アプリケーション内でしか、画面遷移はできません。また、Cross-Page Posting では、別の Web アプリケーションへ遷移できますが、その場合は遷移前の Page オブジェクトを参照できません。遷移前の Page オブジェクトを参照できるのは、同一の Web アプリケーション内の画面遷移だけです。</p>
<h2 id="webapp_sc_cs6">おわりに</h2>
<p>このように、画面遷移方法には複数あり、それぞれ異なる特徴があります。</p>
<p>メニュー画面からの単純な分岐を行う画面遷移であれば、HyperLink などのリンクを使うのが簡単です。画面遷移前に、ポストデータの検&#35388;を行うのであれば、Response.Redirect が適当です。</p>
<p>しかし、これら 2 つは、遷移前の Page オブジェクトを参照できないので、遷移前の Page オブジェクトから複雑なデータを受け取るのであれば、Server.Transfer を使う方法が考えられます。ただし、ブラウザによっては、[戻る] ボタンを押してしまった場合、誤動作する可能性があります。ユーザーが本来はどの画面まで進んだか、画面遷移を追跡する仕組み (ワークフローの進捗を追跡する仕組み)が、サーバー側に必要になるでしょう。(もっとも、信&#38972;性ある本&#26684;的なアプリケーションならば、どの画面遷移方法を問わず、サーバー側でどこまでワークフローが進んだか、追跡する仕組みは必要ですが。)
 もちろん、Server.Transfer でも、遷移前のアドレスにポストするので、遷移前に値の検&#35388;ができます。</p>
<p>さらに、ASP.NET 2.0 では、遷移先に直接ポストする仕組みが登場しました。この方法も、遷移前の Page オブジェクトを参照できます。1 つのページが複数の論理的なフォームに分割されていたとき、フォームごとにポスト先を変えたいときなどに便利です。</p>
<p>それぞれの特色を踏まえた上で適切な使い分けをご検討ください。&nbsp;&nbsp;</p>
<hr>
<div>
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank"><img src="-ff950935.netframework_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt=".NET Framework デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; 10 行でズバリ!! サンプル コード集 (<a href="http://msdn.microsoft.com/ja-jp/netframework/ee708289" target="_blank">C#</a> |
<a href="http://msdn.microsoft.com/ja-jp/netframework/ee708290" target="_blank">VB</a>)
</li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっと .NET Framework の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank">
.NET Framework デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
</div>
</div>
