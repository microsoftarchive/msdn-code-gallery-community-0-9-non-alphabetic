# 10 行でズバリ!! Windows アプリケーションからの Web サービスの利用 (C#)
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Visual Studio 2005
## Topics
- 10 行でズバリ!!
- Web サービス
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
 img,#lspAdd img{border:none;}#lspDontShow{margin:0;padding:0;position:absolute;top:111px;left:8px;float:left;}#lspDontShow a{color:#48819c;font-family:Tahoma;text-decoration:underline;}#lspDontShow a:active,#lspDontShow a:hover{cursor:pointer;}#cps{position:relative;z-index:1001;}#cpsPosCss{height:24px;}.Stoteaserhidden{display:none;height:0;}.internav{background-position:top
 right;background-repeat:no-repeat;float:left;font-family:'Segoe UI Semibold','Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:14px;height:32px;margin:0 0 0 8px;max-width:936px;overflow:hidden;padding:0 37px 0 0;position:relative;white-space:nowrap;}.leftcap{height:32px;left:-29px;position:absolute;width:37px;}.internav
 a{float:left;margin:0;padding:6px 9px;white-space:nowrap;}.internav a:hover{height:20px;margin:1px 0;padding:6px 9px 4px 9px;}.internav a.active,.internav a.active:hover{background:url('../../images/common.png') 0 -43px no-repeat;height:20px;margin:1px 0;padding:5px
 9px;}.LocalNavigation{display:inline-block;font-size:12px;margin:2px 0 0 -17px;padding:0 0 1px 0;white-space:nowrap;width:996px;}.HeaderTabs{margin:0 0 0 25px;width:948px;}.LocalNavigation .TabOff{float:left;white-space:nowrap;}.LocalNavigation .TabOff a{float:left;margin-top:1px;padding:4px
 6px;cursor:pointer;}.LocalNavigation .TabOff a:hover{padding:5px 6px 3px 6px;}.LocalNavigation .TabOn{float:left;margin-top:1px;padding:4px 6px;white-space:nowrap;}.LocalNavigation .TabOn a,.LocalNavigation .TabOn a:hover,.LocalNavigation .TabOn a:visited{cursor:default;text-decoration:none;}.LocalNavBottom{display:none;}.cleartabstrip{clear:both;height:0;}div.ShareThis2{white-space:nowrap;display:block;position:relative;}div.ShareThis2
 a{display:inline-block;background:#fff;}div.ShareThis2 a span.Icon,div.ShareThis2 ul li a span span.Icon{display:inline-block;background-image:url('../../images/headlinesprites.png');background-repeat:no-repeat;width:16px;height:16px;}div.ShareThis2 a span.Label{color:#858585;font-size:85%;position:relative;bottom:4px;}div.ShareThis2
 ul{display:none;background:#fff;padding:5px;position:absolute;left:-9px;list-style:none;margin:0;padding:5px 10px 5px 10px;border:1px solid #ddd;}div.ShareThis2Up ul{bottom:25px;}div.ShareThis2Down ul{top:25px;}div.ShareThis2 ul li{position:relative;list-style:none;padding:3px
 3px 3px 3px;margin:0;}div.ShareThis2 ul li a span{display:inline-block;}div.ShareThis2 ul li a span span.Label{display:inline-block;font-size:90%;position:relative;bottom:3px;padding-left:1px;}div.ShareThis2 a span.Icon{background-position:-89px 0;}div.ShareThis2
 ul li a span span.ShareThisEmail{background-position:-241px 0;}div.ShareThis2 ul li a span span.ShareThisFacebook{background-position:-122px 0;}div.ShareThis2 ul li a span span.ShareThisTwitter{background-position:-138px 0;}div.ShareThis2 ul li a span span.ShareThisDigg{background-position:-154px
 0;}div.ShareThis2 ul li a span span.ShareThisTechnorati{background-position:-170px 0;}div.ShareThis2 ul li a span span.ShareThisDelicious{background-position:-186px 0;}div.ShareThis2 ul li a span span.ShareThisGoogle{background-position:-202px 0;}div.ShareThis2
 ul li a span span.ShareThisMessenger{background-position:-218px 0;}.SearchBox{background-color:#fff;border:solid 1px #346b94;float:left;margin:0 0 12px 0;width:314px;}.TextBoxSearch{border:none;color:#000;float:left;font-size:13px;font-style:normal;margin:0;padding:4px
 0 0 5px;vertical-align:top;width:232px;}.Bing{background:#fff url('../../images/common.png') 0 -20px no-repeat;display:inline-block;float:right;height:22px;overflow:hidden;text-align:right;width:47px;}.SearchButton{background:#fff url('../../images/common.png')
 -48px -19px no-repeat;display:inline-block;border-width:0;cursor:pointer;float:right;height:21px;margin:0;padding:0;text-align:right;vertical-align:top;width:21px;}#SuggestionContainer li{list-style:none outside none;}div.DivRatingsOnly{border:solid 0 red;margin-top:5px;margin-bottom:5px;}.ratingStar{font-size:0;width:16px;height:16px;margin:0;padding:0;cursor:pointer;display:block;background-repeat:no-repeat;}.filledRatingStar{background:url('/Areas/Sto/Content/Theming/Images/LibC.gif')
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
 div.Items .ShareThis2{float:right;position:relative;top:-4px;}div.HeadlineList a.Item .Description,div.HeadlineList a.Item span.Description:hover,div.HeadlineList a.Item span.Description:active{display:inline-block;color:#000;margin-bottom:10px;}.FooterLinks{padding:6px
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
 solid #aaa;border-bottom:1px solid #fff;bottom:2px;}html,body,div,span,applet,object,iframe,h1,h2,h3,h4,h5,h6,p,blockquote,pre,a,abbr,acronym,address,big,cite,code,del,dfn,em,font,img,ins,kbd,q,s,samp,small,strike,strong,sub,sup,tt,var,dl,dt,dd,ol,ul,li,fieldset,form,label,legend,table,caption,tbody,tfoot,thead,tr,th,td{border:0;font-weight:inherit;font-style:inherit;font-family:inherit;margin:0;outline:0;padding:0;}table{border-collapse:separate;border-spacing:0;}html{font-size:100.01%;}body{color:#333;font-family:'Segoe
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
 2px 10px 2px;}p.NoP{margin:0;}.Container p{margin:0;display:block;}div.NoBrandLogo A{background:transparent;color:#fff;height:auto;width:auto;}div.NoBrandLogo span{display:inline;}.RightAdRail2{background-color:#fafafa;}div.PaddedMainColumnContent{padding-left:5px;}h1,.title{margin:5px
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
 .h3,.fullwidth .h3,.MainColumn .h3,.maincolumn .h3,.MiddleColumn .h3,.middlecolumn .h3,.RightColumn .h3,.rightcolumn .h3,.ColumnFifty .h3,.columnfifty .h3{font-size:125%!important;height:26px;padding:5px 0 0 0;}.h3 .rssfeed,.h3 .opmlfeed{position:absolute;right:0;top:4px;}
 ﻿#BodyBackground{background:#ced5db url('../images/logos_and_bg.png') repeat-x 0 -100px;}.BrandLogo,.BrandLogo a,.BrandLogo a:link,.BrandLogo a:visited,.BrandLogo a:hover,.BrandLogo a:active,.GlobalBar,.PassportScarab,.PassportScarab a,.PassportScarab a:link,.PassportScarab
 a:visited,.PassportScarab a:hover,.PassportScarab a:active,.UserName,.UserName a,.UserName a:link,.UserName a:visited,.UserName a:hover,.UserName a:active,a.LocaleManagementFlyoutStaticLink,a:link.LocaleManagementFlyoutStaticLink,a:visited.LocaleManagementFlyoutStaticLink,a:hover.LocaleManagementFlyoutStaticLink,a:active.LocaleManagementFlyoutStaticLink{color:#313131;}.NetworkLogo
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
<p>最終更新日 2005 年 11 月 14 日</p>
<h2><img src="13748-image.png" alt=""> このコンテンツのポイント</h2>
<ul>
<li>Windows アプリケーションから Web サービスの利用方法について理解する。 </li></ul>
<h2><img src="13749-image.png" alt=""> 今回紹介するコード</h2>
<h3>＜Service.cs＞</h3>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">[WebMethod]
public DsAdv GetDepartments() {
    DsAdv ds = new DsAdv ();
    DsAdvTableAdapters. DepartmentTableAdapter adapter
         = new DsAdvTableAdapters. DepartmentTableAdapter();
    adapter.Fill(ds.Department);
    return ds;
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜Form1.cs＞ </strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">private void Form1_Load(object sender, EventArgs e)
{
    localhost.Service srv = new localhost.Service();
    departmentBindingSource.DataSource = srv.GetDepartments();
    departmentBindingSource.DataMember = &quot;Department&quot;;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<h3><img src="13750-image.png" alt=""> 今回のシステム要件</h3>
<ul>
<li>Visual Studio 2005 Beta 2 </li><li>IIS (インターネット インフォメーション サービス) 5.x または 6.0 </li><li>SQL Server 2005 Express Edition (Visual Studio 2005 に付属のもの) </li><li>任意のサンプル データベース (任意の一つのテーブルがあること) </li></ul>
<h3>目次</h3>
<p><a href="#section1">はじめに</a><br>
<a href="#section2">作成するアプリケーションの概要</a><br>
<a href="#section3">Web サービスの作成</a><br>
<a href="#section4">Web サービス クライアントの作成</a><br>
<a href="#section5">動作と解説</a><br>
<a href="#conclusion">おわりに</a></p>
<table border="0" cellspacing="0" cellpadding="5" bgcolor="#e5f1f8">
<tbody>
<tr>
<td colspan="2">Visual Basic の内容はこちらに掲載しています。</td>
</tr>
<tr>
<td align="center"><img src="13751-image.png" alt=""></td>
<td><a href="http://msdn.microsoft.com/ja-jp/netframework/02b57871-2502-4af6-b3b1-fb7493ce8df2">10 行でズバリ!! Windows アプリケーションからの Web サービスの利用 (VB)</a></td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<hr>
<h2 id="section1">はじめに</h2>
<p>ビジネスロジックを Web サービス として実装することで、Windows フォームや Web フォーム、Office アプリケーションなどの様々なクライアント アプリケーションから、サーバー サイドのビジネスロジックを共有することが可能になります。</p>
<p>いわば、マルチクライアントの実現が Web サービスによって可能になります。</p>
<p>ここでは、簡単な Web サービスの作成と、それを利用する Windows アプリケーションの作成を通じて、Web サービスの作成や利用が Visual Studio 2005 によって容易に実現できることを見ていきます。</p>
<p>また、ここで作成した Web サービスは、「<a href="http://msdn.microsoft.com/ja-jp/netframework/cc4d802b-f370-431b-adf3-faf995631914">10 行でズバリ !! Office アプリケーションからの Web サービスの利用 (C#)</a>」や 「<a href="http://msdn.microsoft.com/ja-jp/netframework/482af56b-80db-4e02-9573-74d4de57c69d">10
 行でズバリ !! Web アプリケーションからの Web サービスの利用 (C#)</a>」でも利用し、様々なクライアントから、同じ Web サービスを利用できることを確認します。</p>
<h2 id="section2">作成するアプリケーションの概要</h2>
<p>ここでは、Web サービス側でデータ ベースにアクセスし、データセットをクライアント側に返す Web メソッドを作成します。また、データセットを受け取るクライアントを Windows フォーム アプリケーションとして作成します。このサンプルでは、SQL Server Express を使ってSQL Server 2005 のサンプル データベースである AdventureWorks を利用しますが、ADO.NET を経由して一つのテーブルを照会することができるのであれば、データベースは特に問いません。</p>
<h2 id="section3">Web サービスの作成</h2>
<p>まず、新規にWebサイトを作成します。Visual Studio 2005 の [ファイル] メニューをクリックし、[新規作成] をポイントして、[Web サイト]をクリックします。 すると、[新しい Web サイト] ダイアログボックスが表示されます。</p>
<p>ここでは、[言語] ドロップダウンリストから Visual C# を選択し、テンプレートとして 「ASP.NET Web サービス」 を選択します。 [場所] 欄では、ドロップダウン リストで 「HTTP」を選択します。アドレスとして、任意の仮想ディレクトリ名を指定します (たとえば、 「http://localhost/WebSrvDB」 など)。(図1)</p>
<p>Visual Studio 2005 では、あらかじめローカル ディスクにWeb サービスを作成し、後から IIS 上に配置することもできますが、ここでは手順を簡単にするため、直接 IIS 上に作成します。そのため、[場所] 欄のドロップダウン リストでは、「HTTP」を選択する点に注意してください。今回は、複数のクライアントから利用するので、IIS 上で Web サービスを実行することにします。</p>
<p>設定が済んだら、[OK] をクリックします。Web サービス用の Web サイトが作成されます。</p>
<p><img src="13752-image.png" alt=""></p>
<p><strong>図 1. ASP.NET Web サービスの Web サイトを新規に作成する</strong></p>
<p>次に、この Web サービスがデータベースにアクセスする上で使用する DataSet と TableAdapter を作成します。(DataSet とTableAdapter を含む ADO.NET の基本事項については、「<a href="http://msdn.microsoft.com/ja-jp/netframework/e513b1a7-ae12-4f2c-ac6d-8b761a2e13ec">10 行でズバリ !! ADO.NET と Visual Studio 2005 によるデータアクセス入門</a>」も併せて参照してください。)</p>
<p>ソリューション エクスプローラ上の App_Code ノードを右クリックして、[新しい項目の追加] をクリックします。(通常、Web サービス関連のソース コードは、App_Code フォルダに追加するため、ここでは App_Code フォルダを明示的に右クリックして、追加を行います。)</p>
<p>[新しい項目の追加] ダイアログ ボックスが表示されるので、テンプレートとして「データセット」を選択し、[名前] ボックスには、「DsAdv.xsd」と入力します。(図 2) 設定が済んだら、[追加] をクリックします。</p>
<p><img src="13753-image.png" alt=""></p>
<p><strong>図 2. データセットを追加する</strong></p>
<p>すると、TableAdapter 構成ウィザードが起動します。 (図 3)</p>
<p><img src="13754-image.png" alt=""></p>
<p><strong>図 3. データセットの追加によって、TableAdapter 構成ウィザードが起動する</strong></p>
<p>ここで、[新しい接続] ボタンをクリックします。すると、[接続の追加] ダイアログ ボックスが表示されるので(図 4)、利用可能なデータベースを選択します。</p>
<p><img src="13755-image.png" alt=""></p>
<p><strong>図 4. 接続を指定する</strong></p>
<p>ここでは、プログラム実行時にAdventureWorks のデータベース ファイルをSQL Server Express へアタッチすることにします。AdventureWorks データベース ファイルは、あらかじめ SQL Server 2005 からデタッチして、C:\Test\ に置いておきます。図 4 のように、[データ ソース] 欄では「SQL Server データベース ファイル」を指定し、[データベース ファイル名] 欄では「C:\Test\AdventureWorks_Data.mdf」と指定します。[Windows
 認&#35388;を使用する] オプションを選択して、[OK] をクリックします。</p>
<p>図 3 に戻るので、[次へ] ボタンをクリックします。前述のように、データベース ファイルを指定した場合、プロジェクト内にコピーするか問い合わせが表示されるので (図 5) 、[いいえ] をクリックします。</p>
<p><img src="13756-image.png" alt=""></p>
<p><strong>図 5. プロジェクト内にコピーするか問い合わせが表示される</strong></p>
<p>次に、データベースにアクセスするための接続文字列を、アプリケーション構成ファイル (Web.config) に保存するか問い合わせが表示されます (図 6)。Visual Studio 2005 では、接続文字列はソース コードに書かずに、アプリケーション構成ファイルに切り分けることが可能です。これによって、アプリケーションの運用時に後から接続先を変えるとき、コード修正や再コンパイルをせずに、構成ファイルを変更するだけで済みます。[次の名前で接続を保存する] チェックボックスをチェックしたままにして、[次へ]
 をクリックします。</p>
<p><img src="13757-image.png" alt=""></p>
<p><strong>図 6. 接続文字列は、アプリケーション構成ファイルに保存できる</strong></p>
<p>次に、コマンドの種類を選択する画面 (図 7) では、[SQL ステートメントを使用する] オプションを選択したままにして、[次へ] をクリックします。</p>
<p><img src="13758-image.png" alt=""></p>
<p><strong>図 7. データアクセスに使用するコマンドの種類を指定する</strong></p>
<p>次の画面 (図 8) では、データアクセスに使用する具体的なステートメントを指定します。ここでは、次の SELECT 文を入力します。</p>
<p style="margin:20px 0px; padding:10px; background-color:#dedfde">SELECT DepartmentID, Name, GroupName FROM HumanResources.Department</p>
<p>&nbsp;</p>
<p><img src="13759-image.png" alt=""></p>
<p><strong>図 8. SELECT 文を指定する</strong></p>
<p><strong>注意</strong>: ここで指定する SQL 文は、テーブルを返すものであれば、特に問いません。たき し、このサンプルでは簡単にするため、テーブル全体をデータセットにロードするので、あまり件数が多いテーブルを使用すると、パフォーマンスに影響します。AdventureWorks サンプル データベースでは、テーブルによっては 1万件以上のデータを持つものもあるので、注意してくき さい。</p>
<p>SQL 文の指定が済んだら、[次へ] をクリックします。TableAdapter に生成するメソッドを指定する画面になるので (図 9)、既定のままにして、[次へ] をクリックします。</p>
<p><img src="13760-image.png" alt=""></p>
<p><strong>図 9. TableAdapter のメソッドを指定できる</strong></p>
<p>最後に処理完了の画面が表示されるので (図 10)、[完了] をクリックします。</p>
<p><img src="13761-image.png" alt=""></p>
<p><strong>図 10. ウィザードの実行結果が表示される</strong></p>
<p>ウィザードが完了すると、DsAdv.xsd のデータセット デザイナが開いています。(図 11) このデザイナの状態から、今回のデータセットには、Department テーブルが含まれていることが読み取れます。また、DepartmentTableAdapter という名前の TableAdapter が作成されたことが分ります。このデザイナは、これ以上使用しないので、閉じておきます。</p>
<p><img src="13762-image.png" alt=""></p>
<p><strong>図 11. データセット デザイナが開く</strong></p>
<p>また、ソリューション エクスプローラの App_Code フォルダには、DsAdv.xsd ファイルが追劍 されていることが分ります。(図 12)この DsAdv.xsd ファイルを元に、ASP.NET は動的にDataSet や TableAdapter を生成します。この時点では、DataSet や TableAdapter のソースコードは存在していませんが、Visual Studio からは、これらクラスを参照することができます。</p>
<p><img src="13763-image.png" alt=""></p>
<p><strong>図 12. .xsd ファイルが App_Code フォルダに追加される</strong></p>
<p>これで、DataSet と TableAdapter の準備ができました。</p>
<p>ここで、Service.cs のコード エディタに切り替えます。(既にエディタを閉じている半合、ソリューション エクスプローラ上の App_Code フォルダにある Service.cs をダブルクリックして、開いてください。)</p>
<p>既存の HelloWorld メソッドを削除し、以下のメソッドを追劍 します。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">[WebMethod]
public DsAdv GetDepartments() {
    DsAdv ds = new DsAdv ();
    DsAdvTableAdapters. DepartmentTableAdapter adapter
         = new DsAdvTableAdapters. DepartmentTableAdapter();
    adapter.Fill(ds.Department);
    return ds;
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>このメソッドでは、DataSet である DsAdv オブジェクト (変数ds) と、TableAdapter である DepartmentTableAdapter オブジェクト (変数 adapter) のインスタンスを作り、TableDapter の Fill メソッドを呼び出して、テーブル データを DsAdv オブジェクトの Department テーブルに読み込んでいます。そして、最後に DsAdv オブジェクトを戻り値として返しています。</p>
<p>コードの記述が完了したら、 [ビルド] メニューの [ソリューションのビルド] をクリックして、コンパイル エラーがないか確認しておきます。</p>
<p>ここで、Web サービスの動作を確認します。ソリューション エクスプローラ上の Service.asmx を右クリックし、[ブラウザで表示] をクリックします。</p>
<p>Web サービスの説明ページが開くので、[GetDepartments] リンクをクリックして、メソッドのテスト ページを開きます。</p>
<p>テスト ページで [起動] ボタンを押して、Web サービスのメソッドを呼び出します。以下のように、XML データとして、Department テーブルを含むデータセットが返ることを確認します。(図 13)</p>
<p><img src="13764-image.png" alt=""></p>
<p><strong>図 13. データセットが XML データとして返る</strong></p>
<h2 id="section4">Web サービス クライアントの作成</h2>
<p>ここでは、Web サービス クライアント として、 Windows フォーム アプリケーションを作成します。</p>
<p>もう一つ、Visual Studio 2005 を起動して、新規にプロジェクトを作成します。([ファイル] メニューの [新規作成] をポイントし、[プロジェクト] をクリックします。) ここでは、言語として Visual C# を選択し、プロジェクト ペインでは、 [Windows アプリケーション] テンプレートを選択します。[プロジェクト名] ボックスに任意の名称を入力し(ここでは WinClientCS)、[場所] ボックスに適当なパスを入力して、[OK] ボタンをクリックします。(図 14)</p>
<p>これで Windows フォームによるクライアント アプリケーション開発の準備が完了しました。</p>
<p><img src="13765-image.png" alt=""></p>
<p><strong>図 14. Windows アプリケーション プロジェクトを新規に作成する</strong></p>
<p>クライアント アプリケーションから Web サービスにアクセスするコードを実装する方法として、「Web 参照の追加」 をメニューから行う方法のほかに、[データ ソース] ウィンドウから行うこともできます。ここでは、[データ ソース] ウィンドウをを使用します。</p>
<p>まず、[データ] メニューの [データ ソースの表示] をクリックして、[データ ソース] ウィンドウを表示します。(図 15)</p>
<p><img src="13766-image.png" alt=""></p>
<p><strong>図 15. [データ ソース] ウィンドウ</strong></p>
<p>[データ ソース] ウィンドウの左端にある [新しいデータ ソースの追加] ボタンをクリックします。(ボタンの名称は、マウスポインタをボタンの上に移動することで、ツールヒントとして表示されます。) すると、データ ソース構成ウィザードが起動します。(図 16) ここでは、Web サービスを選択して、[次へ] をクリックします。</p>
<p><img src="13767-image.png" alt=""></p>
<p><strong>図 16. データ ソース構成ウィザード</strong></p>
<p>Web 参照の追加を行う画面になる (図 17) ので、次のアドレスを指定して、[移動] ボタンを押します。</p>
<p style="margin:20px 0px; padding:10px; background-color:#dedfde">http://localhost/WebSrvDB/Service.asmx?wsdl</p>
<p>&nbsp;</p>
<p><img src="13768-image.png" alt=""></p>
<p><strong>図 17. Web 参照の追加を行う</strong></p>
<p>Web サービスに問題なくアクセスできたら、[Web 参照の追加] ボタンをクリックします。</p>
<p>Web 参照の追劍 が完了したことがウィザードに表示されるので (図 18)、[完了] ボタンを押してウィザードを終了します。</p>
<p><img src="13769-image.png" alt=""></p>
<p><strong>図 18. Web 参照の追加が完了する</strong></p>
<p>この操作によって、Web サービスにアクセスするプロキシ クラスが生成されます。また、この Web サービスはデータセット DsAdv を返すので、クライアント側にも受け皿となる DsAdv クラスのソース コードが生成されます。(これらのソースコードのファイルは、既定の設定では、ソリューション エスクプローラに表示されません。ソリューション エクスプローラの上部にある [すべてのファイルを表示] ボタンを押すことで、表示できます。ソース ファイルは、[Web References] ノードから [localhost]、[Reference.map]
 と展開したノードの下の、Reference.cs というファイルの中に記述されています。)</p>
<p>データセットが生成されると、[データ ソース] ウィンドウには、そのデータセットのデータ構逍 が表示されます。(図 19)</p>
<p><img src="13770-image.png" alt=""></p>
<p><strong>図 19. [データ ソース] ウィンドウに Web サービスの戻り値のデータセットが表示される</strong></p>
<p>この [データ ソース] ウィンドウを使用すると、Web サービスの戻り値として返されるデータセットと連結する、ユーザー インターフェイスを簡単に作成することができます。</p>
<p>ここで、Form1.cs の Windows フォーム デザイナを開き、[データ ソース] ウィンドウの Department テーブル ノードを、フォーム デザイナ上にドラッグ アンド ドロップします。すると、フォーム上には Department テーブルを表示するユーザー インターフェイスが自動的に生成されます。(図20)</p>
<p><img src="13771-image.png" alt=""></p>
<p><strong>図 20. データセット内の Departmentテーブルと連結したユーザー インターフェイスが生成される</strong></p>
<p>これで、データセットと連結する部分は完成しました。後は、Web サービスにアクセスして、データセットをクライアントに取り込む部分を作成します。</p>
<p>Form1.cs のデザイナ上の、フォーネ の余白部分をダブルクリックして、Form1_Load イベント ハンドラを生成します。このイベント ハンドラに以下のコードを入力します。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">private void Form1_Load(object sender, EventArgs e)
{
    localhost.Service srv = new localhost.Service();
    departmentBindingSource.DataSource = srv.GetDepartments();
    departmentBindingSource.DataMember = &quot;Department&quot;;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<table id="hpcontenttable" border="0" cellpadding="0">
<tbody>
<tr>
<td>
<p>このコードでは、プロキシ クラスである Service クラスのインスタンスを作り、GetDepartments メソッドを呼び出して、DsAdv データセットを取得しています。</p>
<p>取得したデータセットは、departmentBindingSource オブジェクトの DataSource プロパティに設定しています。このオブジェクトは、フォーム デザイナに Department テーブルをドラッグ アンド ドロップした際に生成されたもので、BindingSource クラスのインスタンスです。BindingSource はデータを提供するオブジェクトで、カレント レコードを管理することができます。画面上の DataGridView と直接的に連結しているのは、このオブジェクトです。(BindingSource
 については、「<a href="http://msdn.microsoft.com/ja-jp/netframework/0a76d484-6929-415f-8d5b-b60d42ef2f2f">10 行でズバリ!! カーソルコントロール (C#)</a>」 を参照してください。)</p>
<h2 id="section5">動作と解説</h2>
<p>ここで、クライアント アプリケーションを実行してみます。[Ctrl] &#43;[F5] キーを押すか、[デバッグ] メニューの [デバッグなしで開始] をクリックします。</p>
<p>フォームが開き、Web サービスから取得したデータセットが DataGridView に表示されることが分ります。(図 21)</p>
<p><img src="13772-image.png" alt=""></p>
<p><strong>図 21. Web サービスから取得したデータセットが表示される</strong></p>
<h2 id="conclusion">おわりに</h2>
<p>このように、Web サービスの実装やクライアントの実装は、Visual Studio の様々なウィザードやデザイナを使うことで、効率よく作成できることができます。典型的なデータセットのやり取りは、数行のコードを記述するだけで、実現することができます。</p>
<p>このような Web サービスを利用するクライアントは、Office アプリケーションや Web アプリケーションとして作成することもできます。これらの様々なクライアント アプリケーションの開発は、Visual Studio 2005 を使用するとで、生産性を向上することができます。Office アプリケーションや Web アプリケーションを Web サービス クライアントとして構築する方法は、それぞれ、「<a href="http://msdn.microsoft.com/ja-jp/netframework/cc4d802b-f370-431b-adf3-faf995631914">
 10 行でズバリ !! Office アプリケーションからの Web サービスの利用 (C#)</a>」、「<a href="http://msdn.microsoft.com/ja-jp/netframework/482af56b-80db-4e02-9573-74d4de57c69d">10 行でズバリ !! Web アプリケーションからの Web サービスの利用 (C#)</a>」を参照してください。</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;<a href="#top"></a> </p>
<hr>
<div>
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img src="http://i.msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank"><img src="http://i.msdn.microsoft.com/ff950935.netframework_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt=".NET Framework デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
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
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
<p></p>
</div>
</div>
