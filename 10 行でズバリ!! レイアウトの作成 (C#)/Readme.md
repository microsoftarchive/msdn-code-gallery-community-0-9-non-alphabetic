# 10 行でズバリ!! レイアウトの作成 (C#)
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2008
- WPF
- Visual Studio 2010
## Topics
- 10 行でズバリ!!
- WPF アプリケーション
## Updated
- 02/13/2011
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
<div class="Clear"></div>
<p>更新日: 2009 年 12 月 25 日</p>
<table border="0" cellspacing="0" cellpadding="5" bgcolor="#e5f1f8" style="margin-bottom:10px">
<tbody>
<tr>
<td style="padding:10px 10px 10px 10px">
<div style="text-align:left; float:left; margin:0pt 9px 9px 0pt"><img src="10275-image.png" alt=""></div>
Visual Basic の内容はこちらに掲載しています。<a href="http://msdn.microsoft.com/ja-jp/netframework/ee916932.aspx">10 行でズバリ !! レイアウトの作成 (VB)</a></td>
</tr>
</tbody>
</table>
<h2><img src="10276-image.png" alt=""> このコンテンツのポイント</h2>
<ul>
<li>WPF アプリケーションにおけるレイアウトの重要性 </li><li>DockPanel パネルによるレイアウト方法 </li><li>Grid パネルによるレイアウト方法 </li></ul>
<h2><img src="10277-image.png" alt=""> 今回紹介するコード</h2>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>
<pre class="hidden"><code class="csharp">&lt;Window x:Class=&quot;LayoutSample.Window1&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    Title=&quot;Window1&quot; Height=&quot;300&quot; Width=&quot;400&quot;&gt;

    &lt;DockPanel Name=&quot;dockPanel1&quot; LastChildFill=&quot;True&quot;&gt;

        &lt;Menu Name=&quot;menu1&quot; DockPanel.Dock=&quot;Top&quot; &gt;
            &lt;MenuItem Header=&quot;ファイル&quot;&gt;&lt;/MenuItem&gt;
            &lt;MenuItem Header=&quot;編集&quot;&gt;&lt;/MenuItem&gt;
        &lt;/Menu&gt;

        &lt;StatusBar Name=&quot;statusBar1&quot; DockPanel.Dock=&quot;Bottom&quot;&gt;
            ステータス バー
        &lt;/StatusBar&gt;

        &lt;Button Name=&quot;button1&quot; DockPanel.Dock=&quot;Bottom&quot;
                Width=&quot;100&quot; Margin=&quot;5&quot; HorizontalAlignment=&quot;Right&quot;&gt;
            送信
        &lt;/Button&gt;

        &lt;Grid Name=&quot;grid1&quot; Margin=&quot;50, 10&quot;&gt;
            
            &lt;!-- 行の定義 --&gt;
            &lt;Grid.RowDefinitions&gt;
                &lt;RowDefinition Height=&quot;Auto&quot; /&gt;
                &lt;RowDefinition Height=&quot;Auto&quot; /&gt;
                &lt;RowDefinition Height=&quot;*&quot; /&gt;
            &lt;/Grid.RowDefinitions&gt;

            &lt;!-- 列の定義 --&gt;
            &lt;Grid.ColumnDefinitions&gt;
                &lt;ColumnDefinition Width=&quot;Auto&quot; /&gt;
                &lt;ColumnDefinition Width=&quot;*&quot; /&gt;
            &lt;/Grid.ColumnDefinitions&gt;
            
            &lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;0&quot; Name=&quot;textBlock1&quot; Text=&quot;住所&quot; VerticalAlignment=&quot;Center&quot; /&gt;
            &lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;1&quot; Name=&quot;textBlock2&quot; Text=&quot;氏名&quot; VerticalAlignment=&quot;Center&quot; /&gt;

            &lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;0&quot; Name=&quot;textBox1&quot; Margin=&quot;5&quot; /&gt;
            &lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;1&quot; Name=&quot;textBox2&quot; Margin=&quot;5&quot; /&gt;

        &lt;/Grid&gt;
    &lt;/DockPanel&gt;
&lt;/Window&gt;</code></pre>
<pre id="codePreview" class="csharp"><code class="csharp">&lt;Window x:Class=&quot;LayoutSample.Window1&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    Title=&quot;Window1&quot; Height=&quot;300&quot; Width=&quot;400&quot;&gt;

    &lt;DockPanel Name=&quot;dockPanel1&quot; LastChildFill=&quot;True&quot;&gt;

        &lt;Menu Name=&quot;menu1&quot; DockPanel.Dock=&quot;Top&quot; &gt;
            &lt;MenuItem Header=&quot;ファイル&quot;&gt;&lt;/MenuItem&gt;
            &lt;MenuItem Header=&quot;編集&quot;&gt;&lt;/MenuItem&gt;
        &lt;/Menu&gt;

        &lt;StatusBar Name=&quot;statusBar1&quot; DockPanel.Dock=&quot;Bottom&quot;&gt;
            ステータス バー
        &lt;/StatusBar&gt;

        &lt;Button Name=&quot;button1&quot; DockPanel.Dock=&quot;Bottom&quot;
                Width=&quot;100&quot; Margin=&quot;5&quot; HorizontalAlignment=&quot;Right&quot;&gt;
            送信
        &lt;/Button&gt;

        &lt;Grid Name=&quot;grid1&quot; Margin=&quot;50, 10&quot;&gt;
            
            &lt;!-- 行の定義 --&gt;
            &lt;Grid.RowDefinitions&gt;
                &lt;RowDefinition Height=&quot;Auto&quot; /&gt;
                &lt;RowDefinition Height=&quot;Auto&quot; /&gt;
                &lt;RowDefinition Height=&quot;*&quot; /&gt;
            &lt;/Grid.RowDefinitions&gt;

            &lt;!-- 列の定義 --&gt;
            &lt;Grid.ColumnDefinitions&gt;
                &lt;ColumnDefinition Width=&quot;Auto&quot; /&gt;
                &lt;ColumnDefinition Width=&quot;*&quot; /&gt;
            &lt;/Grid.ColumnDefinitions&gt;
            
            &lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;0&quot; Name=&quot;textBlock1&quot; Text=&quot;住所&quot; VerticalAlignment=&quot;Center&quot; /&gt;
            &lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;1&quot; Name=&quot;textBlock2&quot; Text=&quot;氏名&quot; VerticalAlignment=&quot;Center&quot; /&gt;

            &lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;0&quot; Name=&quot;textBox1&quot; Margin=&quot;5&quot; /&gt;
            &lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;1&quot; Name=&quot;textBox2&quot; Margin=&quot;5&quot; /&gt;

        &lt;/Grid&gt;
    &lt;/DockPanel&gt;
&lt;/Window&gt;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<h2>目次</h2>
<ol>
<li><a href="#01">はじめに</a> </li><li><a href="#02">レイアウト パネルの種類</a> </li><li><a href="#03">サンプル アプリケーションの画面構成</a> </li><li><a href="#04">WPF アプリケーションの開発準備</a> </li><li><a href="#05">DockPanel パネルによるレイアウト</a> </li><li><a href="#06">メニュー バーの配置</a> </li><li><a href="#07">ステータス バーとボタンの配置</a> </li><li><a href="#08">Grid パネルの配置</a> </li><li><a href="#09">Grid パネルによるレイアウト</a> </li><li><a href="#10">TextBlock コントロールと TextBox コントロールの配置</a> </li><li><a href="#11">グリッドのサイズ指定</a> </li></ol>
<hr>
<h2 id="01">1. はじめに</h2>
<p>WPF (Windows Presentation Foundation) を使用してクライアント アプリケーションのユーザー インターフェイスを作成する際、まず必要となるのがレイアウトです。</p>
<p>WPF でも従来のような位置とサイズを直接指定した部品 (コントロール) の配置は可能ですが、WPF の特性を生かしたユーザー インターフェイスを構築するには、部品の配置の前に、レイアウトをある程度しっかりと設計しておくことが重要となります。これは具体的には、レイアウト用のコントロールであるレイアウト パネルを配置するという作業になります。</p>
<p>ここでは Visual Studio 2008 SP1 (.NET Framework の バージョンは 3.5 SP1) を用いて、サンプル アプリケーションを作成しながら、WPF におけるレイアウトの基本的な作成方法について解説します。なお Visual Studio 2008 でも WPF アプリケーションのデザインや実装は可能ですが、SP1 ではデザイナーの強化や、WPF アプリケーションのパフォーマンス向上などの改善が行われています。</p>
<p style="margin-top:20px"><a href="#top"><img src="10278-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. レイアウト パネルの種類</h2>
<p>WPF では、ウィンドウにまずレイアウト パネル用のコントロールを配置し、その中にボタンやテキストボックスなどのコントロールを配置 (あるいは別のレイアウト パネルを入れ子にして配置) しながら、ユーザー インターフェイスを構築していくのが基本です。</p>
<p>WPF には、主に以下のようなレイアウト パネル用のコントロールが標準で含まれています。</p>
<ul>
<li>Canvas － 位置指定で子コントロールを配置 </li><li>DockPanel － 指定した方向にドッキングして子コントロールを配置 </li><li>Grid － グリッド上の指定した位置に子コントロールを配置 </li><li>StackPanel － 水平または垂直方向に並べて子コントロールを配置 </li><li>WrapPanel － StackPanel と同様に並べて配置するが端で折り返し </li></ul>
<p>ここでは、これらの中でも業務アプリケーションの画面設計において特に重要と思われる DockPanel パネルと Grid パネルについて、実際にレイアウトを行いながら解説していきます。</p>
<p style="margin-top:20px"><a href="#top"><img src="10279-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. サンプル アプリケーションの画面構成</h2>
<p>具体的には、以下のような画面のサンプル アプリケーションを作成していきます。この画面は、住所と氏名の入力フォームを想定しており、上部にメニュー バー、下部にはステータス バーがあり、右下隅にはボタンが配置されています。</p>
<p><img src="10280-image.png" alt=""></p>
<p><strong>図 1. 作成するサンプル アプリケーションの画面</strong></p>
<p>ウィンドウのサイズを変更した場合には、次のような画面となります。メニュー バーとステータス バーの配置やボタンの位置が保たれており、テキストボックスの幅がウィンドウのサイズに従って変更されている点がポイントです。</p>
<p><img src="10281-image.png" alt=""></p>
<p><strong>図 2. サンプル アプリケーションのウィンドウ サイズを変更</strong></p>
<p style="margin-top:20px"><a href="#top"><img src="10282-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. WPF アプリケーションの開発準備</h2>
<p>まず Visual Studio を起動して、[ファイル] メニューの [新規作成] から [プロジェクト] をクリックし、[新しいプロジェクト] ダイアログを開きます。そして [プロジェクトの種類] で [Windows] を、[テンプレート] では [WPF アプリケーション] を選択します。[プロジェクト名] は任意の名前を指定でき、ここでは「LayoutSample」としています。</p>
<p><img src="10283-image.png" alt=""></p>
<p><strong>図 3. [新しいプロジェクト] ダイアログで WPF アプリケーションのプロジェクトを新規作成</strong></p>
<p>[OK] ボタンをクリックすると、次の画面のように WPF デザイナーが開かれます。左端にあるツール ボックスよりウィンドウ上にコントロールをドラッグ アンド ドロップして画面設計を行っていきます。</p>
<p><img src="10284-image.png" alt=""></p>
<p><strong>図 4. プロジェクト新規作成後に開く WPF デザイナーの画面</strong></p>
<p>以降では、DockPanel パネルによるウィンドウ全体のレイアウト決めを行った後、Grid パネルを使用して入力フォーム部分にテキストボックス等を配置していきます。</p>
<p style="margin-top:20px"><a href="#top"><img src="10285-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. DockPanel パネルによるレイアウト</h2>
<p>まずは DockPanel パネルを配置し、メニュー バーをウィンドウ最上部に配置します。</p>
<p>DockPanel パネルは、上下左右の縁 (ふち) に子コントロールをドッキング (Dock) させて配置することのできるレイアウト パネルです。さらに、子コントロールとして挿入する最後のコントロールは、残りの領域をすべて占有させることができます。</p>
<p>ここでは最初に、ツール ボックスから DockPanel パネルをウィンドウ上に配置し、ウィンドウ内にきっちりと収まるようにサイズと位置を調節します。そして、(以降の動作が分かりやすいように) プロパティ ウィンドウで、LastChildFill プロパティの項目のチェックをはずしておいてください。このプロパティは、上述した「最後の子コントロールが、残りの領域をすべて占有する」かどうかを決めるためのものです。</p>
<p><img src="10286-image.png" alt=""></p>
<p><strong>図 5. DockPanel パネルを配置</strong></p>
<p>XAML コード上では、最初から記述されている &lt;Grid&gt; と &lt;/Grid&gt; は不要ですので削除しています。またここでは、ウィンドウのサイズを 400 &times; 300 に変更しています。</p>
<p style="margin-top:20px"><a href="#top"><img src="10287-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="06">6. メニュー バーの配置</h2>
<p>続いて、ツール ボックスより Menu コントロールを DockPanel パネル内に配置します。さらに、プロパティ ウィンドウで DockPanel.Dock プロパティを「Top」に設定します。これにより Menu コントロールが DockPanel パネルの上辺にドッキングします。<br>
<br>
<img src="10288-image.png" alt=""></p>
<p><strong>図 6. メニュー バーを上辺部分に配置</strong></p>
<p>XAML コードでは、&lt;Menu&gt; 要素に設定されている幅と高さ (Width 属性と Height 属性) は不要ですので削除します。同時に、メニュー項目が存在しないとメニュー自体が表示されないので、次の XAML コード (太字) のように適当なメニュー項目を追加しておきます。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>&lt;Window x:Class=&quot;LayoutSample.Window1&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Title=&quot;Window1&quot; Height=&quot;300&quot; Width=&quot;400&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&lt;DockPanel Name=&quot;dockPanel1&quot; LastChildFill=&quot;False&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&lt;Menu Name=&quot;menu1&quot; DockPanel.Dock=&quot;Top&quot; &gt;</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&lt;MenuItem Header=&quot;ファイル&quot;&gt;&lt;/MenuItem&gt;</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&lt;MenuItem Header=&quot;編集&quot;&gt;&lt;/MenuItem&gt;</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&lt;/Menu&gt;</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DockPanel&gt;<br>
&lt;/Window&gt;</p>
</div>
<p style="margin-top:20px"><a href="#top"><img src="10289-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="07">7. ステータス バーとボタンの配置</h2>
<p>続いて、 StatusBar コントロールを DockPanel パネル内に配置します。今回は、DockPanel.Dock プロパティを「Bottom」に設定し、&lt;StatusBar&gt; 要素の Height 属性と Width 属性を削除します。また、ステータス バーに表示される適当な文字列も設定しておきます。最終的には、&lt;StatusBar&gt; 要素は次のようになります。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>
<pre class="hidden"><code class="csharp">&lt;StatusBar Name=&quot;statusBar1&quot; DockPanel.Dock=&quot;Bottom&quot; &gt;
    ステータス バー
&lt;/StatusBar&gt;</code></pre>
<pre id="codePreview" class="csharp"><code class="csharp">&lt;StatusBar Name=&quot;statusBar1&quot; DockPanel.Dock=&quot;Bottom&quot; &gt;
    ステータス バー
&lt;/StatusBar&gt;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>ステータス バーはうまく DockPanel パネルの下辺部分に表示されているでしょうか。</p>
<p>次は、DockPanel.Dock プロパティを「Bottom」に設定した Button コントロールを配置します。これにより下から 2 番目 (ステータス バーが一番下で、そのすぐ上) にボタンが配置されることになります。このように、DockPanel.Dock プロパティの値が同じ子コントロールが複数存在する場合は、XAML コードでの記述の順に従って、それぞれの縁の部分に重なっていきます。</p>
<p>ボタンに関しては、右寄せにして、幅を指定しておきます。またステータス バーとぴったりくっつくと不&#26684;好なので、適当にマージンを指定します。最終的には、&lt;Button&gt; 要素は次のようになります。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>
<pre class="hidden"><code class="csharp">&lt;Button Name=&quot;button1&quot; DockPanel.Dock=&quot;Bottom&quot;
        Width=&quot;100&quot; Margin=&quot;5&quot; HorizontalAlignment=&quot;Right&quot;&gt;
    送信
&lt;/Button&gt;</code></pre>
<pre id="codePreview" class="csharp"><code class="csharp">&lt;Button Name=&quot;button1&quot; DockPanel.Dock=&quot;Bottom&quot;
        Width=&quot;100&quot; Margin=&quot;5&quot; HorizontalAlignment=&quot;Right&quot;&gt;
    送信
&lt;/Button&gt;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p style="margin-top:20px"><a href="#top"><img src="10290-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="08">8. Grid パネルの配置</h2>
<p>最後に Grid パネルをツール ボックスから配置してください。そしてここで、先ほどチェックをはずした DockPanel パネルの LastChildFill プロパティにチェックを入れてください (XAML コード上で、&lt;DockPanel&gt; 要素から LastChildFill 属性の記述を削除しても構いません)。さらに、&lt;Grid&gt; 要素に設定されている Height 属性と Width 属性を削除します。これにより画面は次のようになります。</p>
<p><img src="10291-image.png" alt=""></p>
<p><strong>図 7. Grid パネルを配置</strong></p>
<p>この状態では、いま追加した Grid パネルが最後の子コントロールとなりますので、自動的にウィンドウの中央部分全体に Grid パネルが表示 (Fill) されるようになります。</p>
<p style="margin-top:20px"><a href="#top"><img src="10292-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="09">9. Grid パネルによるレイアウト</h2>
<p>以降では、最後に配置した Grid パネル内に 2 つのテキスト (住所、氏名) と 2 つのテキストボックスを配置していきます。</p>
<p>Grid パネルでは、パネル内をグリッド (縦 m 行、横 n 列の&#26684;子状) に分割し、子コントロールを配置していきます。配置する子コントロール側では、グリッド内のどのセルの位置にそれが配置されるかを、行番号と列番号で指定します。</p>
<p>まず Grid パネルにグリッドを設ける作業が必要になります。これを WPF デザイナーで行うには、Grid パネルを選択し、Grid パネルの左辺と上辺の縁に表示されている水色部分をクリックします。これによりグリッド線が追加されます。グリッド線を消すには、Grid パネルの外にグリッド線を移動させます。</p>
<p>次の画面は、2 本の横方向のグリッド線と、1 本の縦方向のグリッド線を追加したところです。</p>
<p><img src="10293-image.png" alt=""></p>
<p><strong>図 8. Grid パネルにグリッド線を追加</strong></p>
<p>上図の XAML コードを見ると、グリッド線に従って、2 つの列と 3 つの行の定義が追加されているのが分かります (&lt;Grid.ColumnDefinitions&gt; 要素と &lt;Grid.RowDefinitions&gt; 要素)。なお、Grid パネルには、左右 50 ピクセル、上下 10 ピクセルのマージンを設定しています。</p>
<p style="margin-top:20px"><a href="#top"><img src="10294-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="10">10. TextBlock コントロールと TextBox コントロールの配置</h2>
<p>続いて、 Grid パネル内の左上隅のセルに TextBlock コントロール (Text プロパティを「住所」に設定) を配置します。このとき、セルのサイズとぴったり同じになるように配置すると、&lt;TextBlock&gt; 要素には Height 属性や Width 属性は設定されません。Grid パネルでは、このように、グリッドの定義部分で行や列のサイズを設定し、子コントロール側ではそのサイズを指定しないというのが基本です。</p>
<p><img src="10295-image.png" alt=""></p>
<p><strong>図 9. Grid パネルの左上隅のセルに TextBlock コントロールを配置</strong></p>
<p>同様にして、もう 1 つの TextBlock コントロール (Text プロパティを「氏名」に設定) と、2 つのテキストボックスを各セルに配置します。このとき、2 つの TextBlock コントロールが垂直方向で中央になるように、VerticalAlignment プロパティを「Center」に設定しておきます。また、2 つの TextBox コントロールがくっつくと不&#26684;好ですので、Margin プロパティを設定しておきます。</p>
<p>ここまでで、Grid パネル部分の XAML コードは次のようになります。(Visual Studioでは Grid.Column=&quot;0&quot; と Grid.Row=&quot;0&quot; の記述が省略されますが、以下では分かりやすいように、すべて明記しています。)</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>
<pre class="hidden"><code class="csharp">&lt;Grid Name=&quot;grid1&quot; Margin=&quot;50, 10&quot;&gt;

    &lt;!-- 行の定義 --&gt;
    &lt;Grid.RowDefinitions&gt;
        &lt;RowDefinition Height=&quot;30*&quot; /&gt;
        &lt;RowDefinition Height=&quot;30*&quot; /&gt;
        &lt;RowDefinition Height=&quot;101*&quot; /&gt;
    &lt;/Grid.RowDefinitions&gt;

    &lt;!-- 列の定義 --&gt;
    &lt;Grid.ColumnDefinitions&gt;
        &lt;ColumnDefinition Width=&quot;40*&quot; /&gt;
        &lt;ColumnDefinition Width=&quot;238*&quot; /&gt;
     &lt;/Grid.ColumnDefinitions&gt;

    &lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;0&quot; Name=&quot;textBlock1&quot; Text=&quot;住所&quot; VerticalAlignment=&quot;Center&quot; /&gt;
    &lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;1&quot; Name=&quot;textBlock2&quot; Text=&quot;氏名&quot; VerticalAlignment=&quot;Center&quot; /&gt;

    &lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;0&quot; Name=&quot;textBox1&quot; Margin=&quot;5&quot; /&gt;
    &lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;1&quot; Name=&quot;textBox2&quot; Margin=&quot;5&quot; /&gt;
&lt;/Grid&gt;</code></pre>
<pre id="codePreview" class="csharp"><code class="csharp">&lt;Grid Name=&quot;grid1&quot; Margin=&quot;50, 10&quot;&gt;

    &lt;!-- 行の定義 --&gt;
    &lt;Grid.RowDefinitions&gt;
        &lt;RowDefinition Height=&quot;30*&quot; /&gt;
        &lt;RowDefinition Height=&quot;30*&quot; /&gt;
        &lt;RowDefinition Height=&quot;101*&quot; /&gt;
    &lt;/Grid.RowDefinitions&gt;

    &lt;!-- 列の定義 --&gt;
    &lt;Grid.ColumnDefinitions&gt;
        &lt;ColumnDefinition Width=&quot;40*&quot; /&gt;
        &lt;ColumnDefinition Width=&quot;238*&quot; /&gt;
     &lt;/Grid.ColumnDefinitions&gt;

    &lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;0&quot; Name=&quot;textBlock1&quot; Text=&quot;住所&quot; VerticalAlignment=&quot;Center&quot; /&gt;
    &lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;1&quot; Name=&quot;textBlock2&quot; Text=&quot;氏名&quot; VerticalAlignment=&quot;Center&quot; /&gt;

    &lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;0&quot; Name=&quot;textBox1&quot; Margin=&quot;5&quot; /&gt;
    &lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;1&quot; Name=&quot;textBox2&quot; Margin=&quot;5&quot; /&gt;
&lt;/Grid&gt;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>行番号や列番号は「0」から始まります。ここでは、例えば、「住所」がグリッドの 1 行 1 列目に配置されているのが分かります。</p>
<p style="margin-top:20px"><a href="#top"><img src="10296-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="11">11. グリッドのサイズ指定</h2>
<p>Visual Studio で [F5] キー (デバッグ実行) を押して実行してみると分かるように、このままではウィンドウのサイズに従ってグリッドの間隔も自動的に調整され、それに応じてテキストボックスのサイズまで変わってしまいます (テキストボックスのフォント サイズは変化しません)。</p>
<p>そこで、行と列の定義部分で、高さと幅の指定を次のように変更します。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>&lt;Grid Name=&quot;grid1&quot; Margin=&quot;50, 10&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&lt;!-- 行の定義 --&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.RowDefinitions&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition <strong>Height=&quot;Auto&quot;</strong> /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition <strong>Height=&quot;Auto&quot;</strong> /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition <strong>Height=&quot;*&quot;</strong> /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&lt;!-- 列の定義 --&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.ColumnDefinitions&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ColumnDefinition <strong>Width=&quot;Auto&quot;</strong> /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ColumnDefinition <strong>Width=&quot;*&quot;</strong> /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;0&quot; Name=&quot;textBlock1&quot; Text=&quot;住所&quot; VerticalAlignment=&quot;Center&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock Grid.Column=&quot;0&quot; Grid.Row=&quot;1&quot; Name=&quot;textBlock2&quot; Text=&quot;氏名&quot; VerticalAlignment=&quot;Center&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;0&quot; Name=&quot;textBox1&quot; Margin=&quot;5&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox Grid.Column=&quot;1&quot; Grid.Row=&quot;1&quot; Name=&quot;textBox2&quot; Margin=&quot;5&quot; /&gt;<br>
&lt;/Grid&gt;</p>
</div>
<p>「Auto」を指定すると、配置されている子コントロールのサイズにあわせて、列や行のサイズが決まるようになります。これに対して「*」を指定すると、その列や行が残りの部分を占めるようになります。上記の記述では、1 列目の幅と、1 行目および 2 行目の高さが固定されることになります。</p>
<p>最終的なデザイン画面は次のようになります。</p>
<p><img src="10297-image.png" alt=""></p>
<p><strong>図 10. 完成したサンプル アプリケーションの画面</strong></p>
<p>なお、ここで紹介した Grid パネルを使ったグリッドの幅や高さの指定方法は一例であり、ほかにもさまざまな指定方法があります。詳しくは、MSDN の<a href="http://msdn.microsoft.com/ja-jp/library/system.windows.controls.grid.aspx">「Grid クラス」</a>の解説をご覧ください。</p>
<hr>
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank"><img src="-ff950935.windows_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Windows デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; 10 行でズバリ!! サンプル コード集 (<a href="http://msdn.microsoft.com/ja-jp/netframework/ee708289" target="_blank">C#</a> |
<a href="http://msdn.microsoft.com/ja-jp/netframework/ee708290" target="_blank">VB</a>)
</li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっと Windows の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank">
Windows デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
</div>
