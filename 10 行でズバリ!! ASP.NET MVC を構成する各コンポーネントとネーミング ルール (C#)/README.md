# 10 行でズバリ!! ASP.NET MVC を構成する各コンポーネントとネーミング ルール (C#)
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- ASP.NET MVC
## Topics
- 10 行でズバリ!!
- ASP.NET MVC アプリケーション
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
<div class="Clear"></div>
<div class="Clear"></div>
<p>更新日: 2010 年 4 月 9 日</p>
<table border="0" cellspacing="0" cellpadding="5" bgcolor="#e5f1f8" style="margin-bottom:10px">
<tbody>
<tr>
<td style="padding:10px 10px 10px 10px">
<div style="text-align:left; float:left; margin:0pt 9px 9px 0pt"><img src="9033-image.png" alt=""></div>
Visual Basic の内容はこちらに掲載しています。<a href="http://msdn.microsoft.com/ja-jp/netframework/ff606598.aspx">10 行でズバリ!! ASP.NET MVC を構成する各コンポーネントとネーミング ルール (VB)</a></td>
</tr>
</tbody>
</table>
<h2><img src="9034-image.png" alt=""> このコンテンツのポイント</h2>
<ul>
<li>ASP.NET MVC アプリケーションの基本的な作成手順の理解 </li><li>MVC (Model - View - Controller) を構成するコンポーネントの命名規則の理解 </li></ul>
<h2><img src="9035-image.png" alt=""> 今回紹介するコード</h2>
<p><strong>&lt;AddressController.cs&gt;</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">public class AddressController : Controller
{
    //
    // GET: /Address/

    public ActionResult Index()
    {
        // (1) コンテキスト クラスをインスタンス化
        var db = new AdventureWorksLT_DataEntities();

        // (2) Address テーブルからすべてのデータを取得
        var list = from a in db.Address
                   orderby a.PostalCode ascending
                   select a;

        // (3) 取得したモデルをビュー スクリプトに引き渡す
        return View(list);
    }
    ...</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>&lt;Index.aspx&gt;</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">...
    &lt;%-- (1) モデルの内容を順に出力 --%&gt;
    &lt;% foreach (var item in Model) { %&gt;
    
        &lt;tr&gt;
            &lt;td&gt;
                &lt;%-- (2) 編集、詳細画面へのリンクを生成 --%&gt;
                &lt;%= Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, new { id=item.AddressID }) %&gt; |
                &lt;%= Html.ActionLink(&quot;Details&quot;, &quot;Details&quot;, new { id=item.AddressID }) %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%= Html.Encode(item.AddressID) %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%= Html.Encode(item.AddressLine1) %&gt;
            &lt;/td&gt;
    ...
            &lt;td&gt;
                &lt;%= Html.Encode(String.Format(&quot;{0:g}&quot;, item.ModifiedDate)) %&gt;
            &lt;/td&gt;
        &lt;/tr&gt;
    
    &lt;% } %&gt;
    ...</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<h2>目次</h2>
<ol>
<li><a href="#01">はじめに</a> </li><li><a href="#02">作成するアプリケーションとデータベースの準備</a> </li><li><a href="#03">ASP.NET MVC アプリケーションの開発準備</a> </li><li><a href="#04">データ モデルの準備</a> </li><li><a href="#05">コントローラー クラスの作成</a> </li><li><a href="#06">ビュー スクリプトの作成</a> </li><li><a href="#07">ASP.NET MVC アプリケーションの実行</a> </li><li><a href="#08">おわりに</a> </li></ol>
<hr>
<h2 id="01">1. はじめに</h2>
<p>従来型の ASP.NET (Web フォーム) の世界は、UI (ユーザー インターフェイス) 中心の開発モデルでした。これは Windows フォームでの開発に慣れた開発者にとって理解しやすいものである半面、単体テストを実施しにくいという問題をはらんでいます。Web フォームでは、ビジネス ロジックの単体のテストを行うにも、ブラウザーを起動してフォームの操作をしなければなりません。</p>
<p>また、Web フォームでは、ビジネス ロジックの多くが UI 上で発生したイベントをトリガーに呼び出されます。「ボタンをクリックした」「テキスト ボックスの値を変更した」などのイベントはすべて UI に対する操作に対して発生するものです。これもまた、テストを自動化しにくくする要因です。</p>
<p>そのような事情から、UI とビジネス ロジックとを明確に分離できるように、と開発されたのが、本稿で解説する ASP.NET MVC です。ASP.NET MVC は名前のとおり、MVC (Model - View - Controller) パターンに則ってアプリケーションを構築するためのフレームワークです。MVC パターンとは、アプリケーションをその役割ごとに Model (ビジネス ロジック)、View (レイアウト)、Controller (Model と View との橋渡し) の 3 つに、明確に分離してプログラミングしましょうという設計モデルです。</p>
<table class="grid" border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse:collapse; margin-bottom:10px; width:600px">
<tbody>
<tr>
<td width="25%" valign="top" bgcolor="#cccccc"><strong>要素</strong></td>
<td width="75%" valign="top" bgcolor="#cccccc"><strong>概要</strong></td>
</tr>
<tr>
<td valign="top"><strong>Model</strong></td>
<td valign="top">データベースへのアクセスなど、データの管理と操作を担当。エンティティ (データ表現) やレポジトリ クラス (データ操作) などから構成</td>
</tr>
<tr>
<td valign="top"><strong>View</strong></td>
<td valign="top">Model から取得したデータをもとに生成される最終的な結果ページ (.aspx ファイル)。ビュー スクリプトあるいはビュー テンプレートとも呼ばれる</td>
</tr>
<tr>
<td valign="top"><strong>Controller</strong></td>
<td valign="top">Model と View との橋渡し役 (コントローラー クラス)。View から受け取ったユーザーの入力データを Model に渡し、Model での処理結果を View にフィードバック</td>
</tr>
</tbody>
</table>
<p><strong>表 1 MVC パターンの構成要素</strong></p>
<p>ASP.NET MVC の世界では、たとえば Controller を表すコントローラー クラスも普通の .NET のクラスにすぎませんので、Web サーバーを用意しなくても、そのまま単体テストを実施できます。また、MVC パターンは、Java や PHP、Ruby など .NET 以外の環境ではおなじみのアーキテクチャですので、これらの環境でフレームワーク プログラミングを行ったことがある方ならば、ASP.NET MVC にはごく親しみやすいはずです。</p>
<p>ここではASP.NET MVC を利用した Web アプリケーションを開発する基本的な手順を紹介します。</p>
<p>なお ASP.NET MVC では、コントローラー クラス (Controller)、ビュー スクリプト (View) それぞれに名前付けのルールがあり、実行時にもそれぞれの名前をキーに、必要なモジュールが呼び出されます。サンプルを作成していく中で、それぞれの命名規則や Controller と View の関連性を理解してください。</p>
<p style="margin-top:20px"><a href="#top"><img src="9036-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. 作成するアプリケーションとデータベースの準備</h2>
<p>ここではサンプルとして、以下の図のようなアプリケーションを作成していきます。データベースから取得した住所データをもとに一覧表を作成するアプリケーションです。</p>
<p><img src="9037-image.png" alt=""></p>
<p><strong>図 1 今回作成するサンプル アプリケーションの画面</strong></p>
<p>なお、本稿ではサンプル データベースとして、AdventureWorksLT データベースを利用します。データベース ファイルである「AdventureWorksLT_Data.mdf」を入手するには、<a href="http://msftdbprodsamples.codeplex.com/releases/view/4004" target="_blank">このページ (英語) (http://msftdbprodsamples.codeplex.com/releases/view/4004)</a>
 から AdventureWorksLT.msi をダウンロードしてインストールしてください。これにより、データベース ファイルである AdventureWorksLT_Data.mdf が作成されます。</p>
<p style="margin-top:20px"><a href="#top"><img src="9038-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. ASP.NET MVC アプリケーションの開発準備</h2>
<p>最初に ASP.NET MVC アプリケーションを開発するための準備を行います。Visual Studio を起動して、[ファイル] メニューの [新規作成] から [プロジェクト] をクリックし、[新しいプロジェクト] ダイアログを開きます。そして [インストールされたテンプレート] で [Web] を、[テンプレート] では [ASP.NET MVC 2 Web Application] を選択します。[名前]、[ソリューション名] には任意の名前を指定でき、ここではそれぞれ「MvcBeginCs」「MvcBegin」としました。</p>
<p><img src="9039-image.png" alt=""></p>
<p><strong>図 2 [新しいプロジェクト] ダイアログで ASP.NET MVC アプリケーションのプロジェクトを新規作成</strong></p>
<p>[OK] ボタンをクリックすると、次に [Create Unit Test Project] ダイアログが開きます。ここではアプリケーション プロジェクトと合わせて、単体テストのためのプロジェクトを作成するかどうかを決めます。今回は単体テストについては扱いませんが、今後に備えて、[Yes, create a unit test project] (テスト プロジェクトを作成します) を選択しておきます。</p>
<p><img src="9040-image.png" alt=""></p>
<p><strong>図 3 [Create Unit Test Project] ダイアログでテスト プロジェクトを作成するかどうかを指定</strong></p>
<p>[OK] ボタンをクリックすると、新規のプロジェクトが作成されます。ソリューション エクスプローラーから、以下のようなフォルダー、ファイルが配置されていることを確認してください。</p>
<p><img src="9041-image.png" alt=""></p>
<p><strong>図 4 プロジェクト作成直後のソリューション エクスプローラー</strong></p>
<p>それぞれのフォルダーの役割は、以下のとおりです。これから作成するクラスやスクリプトは、まずはそれぞれの役割に応じて、決められたフォルダーに配置する必要があります。</p>
<table class="grid" border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse:collapse; margin-bottom:10px; width:600px">
<tbody>
<tr>
<td width="25%" valign="top" bgcolor="#cccccc"><strong>フォルダー名</strong></td>
<td width="75%" valign="top" bgcolor="#cccccc"><strong>フォルダーの内容</strong></td>
</tr>
<tr>
<td valign="top"><strong>Controllers</strong></td>
<td valign="top">個別のリクエストを処理するためのコントローラー クラス</td>
</tr>
<tr>
<td valign="top"><strong>Models</strong></td>
<td valign="top">データベースなどを操作するためのクラス</td>
</tr>
<tr>
<td valign="top"><strong>Views</strong></td>
<td valign="top">最終的な画面を生成するためのビュー スクリプト</td>
</tr>
<tr>
<td valign="top"><strong>Scripts</strong></td>
<td valign="top">JavaScript のライブラリ</td>
</tr>
<tr>
<td valign="top"><strong>Content</strong></td>
<td valign="top">画像ファイルや CSS スタイル シートなど</td>
</tr>
<tr>
<td valign="top"><strong>App_Data</strong></td>
<td valign="top">アプリケーションで使用するデータ ファイル (.mdf ファイルなど)</td>
</tr>
</tbody>
</table>
<p><strong>表 1 [ASP.NET MVC 2 Web Application] プロジェクトの初期フォルダ</strong>ー</p>
<p>フォルダーの構造が確認できたら、「App_Data」フォルダーに先ほどインストールした AdventureWorksLT_Data.mdf をインポートしておきます。既存のファイルをインポートするには、ソリューション エクスプローラー から「App_Data」フォルダーを右クリックし、[追加] - [既存の項目] を選択してください。[既存の項目の追加] ダイアログが起動しますので、AdventureWorksLT_Data.mdf を選択します。AdventureWorksLT_Data.mdf は、デフォルトで「C:\Program
 Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data」にインストールされています。</p>
<p><img src="9042-image.png" alt=""></p>
<p><strong>図 5 [既存の項目の追加] ダイアログで、データベース ファイルをインポート</strong></p>
<p style="margin-top:20px"><a href="#top"><img src="9043-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. データベースとエンティティ データ モデルの準備</h2>
<p>プロジェクトを作成できたら、次にデータ モデルを準備します。Model - View - Controller の Model に相当する部分です。</p>
<p>データ モデルとは、データベースにアクセスするための機能を提供するコンテキスト オブジェクト、そして、取得したデータを&#26684;納するためのエンティティなどから構成されるオブジェクト群をいいます。ASP.NET MVC では、データ モデルとして ADO.NET Entity Framework が提供するエンティティ データ モデルや、LINQ to SQL クラスを利用できます。本稿では、エンティティ データ モデルを前提に手順を進めます。</p>
<p>エンティティ データ モデルを作成するには、ソリューション エクスプローラーから Models フォルダーを右クリックし、表示されたコンテキスト メニューから[追加] - [新しい項目]を選択します。[新しい項目の追加] ダイアログが開きますので、[インストールされたテンプレート] で [データ] を、[テンプレート] では [ADO.NET Entity Data Model] を選択します。[名前] には任意の名前を指定でき、ここでは「AdventureWorksLT」としました。</p>
<p><img src="9044-image.png" alt=""></p>
<p><strong>図 6 エンティティ データ モデルを新規に作成</strong></p>
<p>以降の手順については、「<a href="http://msdn.microsoft.com/ja-jp/netframework/ee851689.aspx">10 行でズバリ !! 概念モデルの作成 (EDM) (C#)</a>」を参考に進めてください。途中、[データ接続の選択] 画面では「AdventureWorksLT_Data.mdf」を選択、[データベース オブジェクトの選択] 画面では、先頭にある [テーブル] にチェックを入れて、データベースに含まれているすべてのテーブルを選択します。</p>
<p>最終的には、以下のようなデザイナー画面が表示されれば、正しくデータ モデルは作成できています。これによって、データベースにアクセスするためのコンテキスト クラス (AdventureWorksLT_DataEntities クラス) や、データベースのテーブルに対応した Address クラスや Customer クラスなどのエンティティ クラスが生成されているはずです。</p>
<p><img src="9045-image.png" alt=""></p>
<p><strong>図 7 ウィザードによって自動生成されたエンティティ データ モデル</strong></p>
<p>デザイナー画面を閉じたら、[ビルド] メニューから [ソリューションのビルド] をクリックし、ソリューションをビルドしておきましょう。データ モデルを作成したタイミングでビルドしておかないと、以降で正しくデータ モデルが認識されない場合がありますので、注意してください。</p>
<p style="margin-top:20px"><a href="#top"><img src="9046-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. コントローラー クラスの作成</h2>
<p>データ モデルの用意ができたところで、次にコントローラー クラスを作成します。コントローラー クラスは、クライアント (ブラウザー) から送信されたリクエストを処理するためのクラスです。Model - View - Controller の Controller に相当する部分です。</p>
<p>コントローラー クラスを作成するには、ソリューション エクスプローラーで「/Controllers」フォルダーを右クリックし、表示されたコンテキスト メニューから [追加] - [Controller] を選択してください。[Add Controller] ダイアログが表示されますので、[Controller Name] (コントローラー名) に「AddressController」と入力します。デフォルトは「DefaultController」となっており、「Default」の部分が選択状態になっていますので、そのまま「Address」と書き換えてください。コントローラー
 クラスの名前は、最後が「Controller」でなければならないため、「Controller」の部分は削除しないようにしてください。</p>
<p>ASP.NET MVC では、クラス名から「Controller」を除いた部分をコントローラー名と見なします。つまり、ここでは Address コントローラーを作成するという意味になります。</p>
<p>また、[Add action methods for Create, Update and Details scenarios] (データの作成、更新、詳細シナリオのためのアクションを追加する) にもチェックを入れておきましょう。これによって、データベースに対するデータの登録/更新、指定データの表示などを行うための骨組みとなるコードを自動生成できます。</p>
<p><img src="9047-image.png" alt=""></p>
<p><strong>図 8 [Add Controller] ダイアログ</strong></p>
<p>[OK] ボタンをクリックすると、コード エディターに AddressController.cs の骨組みとなるコードが表示されます。Index、Details、Create、Edit のようなメソッドが自動生成されていますが、本稿では Index メソッド にコードを追加します。ここでは最終的に次のようなコードになるように、コード エディターで入力/編集を行ってください。太字の部分が実際に入力する必要のあるコードです。</p>
<div style="margin:2px 0px; padding:5px 5px 0px 5px; background-color:#dedfde">
<p>using System;<br>
using <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;<br>
using <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;<br>
using <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;<br>
using <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;<br>
using <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.Mvc.Ajax.aspx" target="_blank" title="Auto generated link to System.Web.Mvc.Ajax">System.Web.Mvc.Ajax</a>;<br>
<strong>using MvcBeginCs.Models;</strong></p>
<p>namespace MvcBeginCs.Controllers<br>
{<br>
public class AddressController : Controller<br>
{<br>
//<br>
// GET: /Address/</p>
<p>public ActionResult Index()<br>
{<br>
// (1) コンテキスト クラスをインスタンス化 <br>
<strong>var db = new AdventureWorksLT_DataEntities();</strong></p>
<p><strong>&nbsp;</strong>// (2) Address テーブルからすべてのデータを取得 <br>
<strong>var list = from a in db.Address</strong><br>
<strong>orderby a.PostalCode ascending</strong><br>
<strong>select a;</strong></p>
<p><strong>&nbsp;</strong>// (3) 取得したモデルをビュー スクリプトに引き渡す <br>
<strong>&nbsp;</strong>return View(<strong>list</strong>);<br>
}<br>
...中略...<br>
}<br>
}</p>
</div>
<p>コントローラー クラスの中で定義されたパブリックなメソッド (ここでは Index メソッド) のことを「アクション メソッド」といいます。具体的なリクエスト処理は、このアクション メソッドに記述します。コントローラー クラスのクラス名と違って、アクション メソッドに命名規則はありません。つまり、Index メソッドを定義するとは、そのまま Index アクションを定義したことになります。</p>
<p>具体的なコードの中身についても見ておきましょう。</p>
<p>(1) の AdventureWorksLT_DataEntities クラスは、先ほど作成したデータ モデルに含まれるコンテキスト クラスです。</p>
<p>Index アクションでは、(2) の部分で、この AdventureWorksLT_DataEntities オブジェクトの Address プロパティにアクセスし、Address テーブルのレコード群を Address エンティティ (Address オブジェクト) の集合として取り出しています。orderby 句は、取得した Address オブジェクト を PostalCode プロパティ (郵便番号) について昇順 (ascending) に並び替えなさいという意味です。</p>
<p>コンテキスト クラス経由で取得した Address オブジェクトの集合 (実際には IQueryable&lt;Address&gt; オブジェクトです) は、アクション メソッドの最後で、(3) のように View メソッドに引き渡すのが基本です。これによって、Address オブジェクトは対応するビュー スクリプトに引き渡され、表示さます。</p>
<p style="margin-top:20px"><a href="#top"><img src="9048-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="06">6. ビュー スクリプトの作成</h2>
<p>ASP.NET MVC で Model での処理結果を受け、最終的な画面を生成するのは、ビュー スクリプトの役割です。Model - View - Controller の最後の 1 つである View を担当します。</p>
<p>ビュー スクリプトを作成するには、コード エディターでアクション メソッドにカーソルを合わせた状態でマウスを右クリックし、表示されるコンテキスト メニューから [Add View] を選択します。</p>
<p><img src="9049-image.png" alt=""></p>
<p><strong>図 9 [Add View] ダイアログ</strong></p>
<p>[Add View] ダイアログが表示されますので、次の表の内容に従って必要な情報を入力します。</p>
<table class="grid" border="1" cellspacing="0" cellpadding="5" width="100%" style="border-collapse:collapse; margin-bottom:10px; width:500px">
<tbody>
<tr>
<td width="45%" valign="top" bgcolor="#cccccc"><strong>項目</strong></td>
<td width="55%" valign="top" bgcolor="#cccccc"><strong>設定値</strong></td>
</tr>
<tr>
<td valign="top"><strong>View name</strong></td>
<td valign="top">Index</td>
</tr>
<tr>
<td valign="top"><strong>Create a strongly-typed view</strong></td>
<td valign="top">チェック</td>
</tr>
<tr>
<td valign="top"><strong>View data class</strong></td>
<td valign="top">MvcBeginCs.Models.Address</td>
</tr>
<tr>
<td valign="top"><strong>View content</strong></td>
<td valign="top">List</td>
</tr>
<tr>
<td valign="top"><strong>Select master page</strong></td>
<td valign="top">チェック (~/Views/Shared/Site.Master)</td>
</tr>
<tr>
<td valign="top"><strong>ContentPlaceHolder ID</strong></td>
<td valign="top">MainContent</td>
</tr>
</tbody>
</table>
<p>表 2 [Add View] ダイアログへの入力項目</p>
<p>[View Name] (ビュー名) には、アクション メソッドに対応する名前 (ここでは Index) がデフォルトでセットされていますので、そのままにしておきます。</p>
<p>[Create a strongly-typed view] (強く型付けされたビューを生成) は、使用するモデルをビュー スクリプトに登録するかどうかを決めるオプションです。型付けを行うことで、ビュー スクリプトを編集する際に、モデルに含まれるプロパティに対しても IntelliSense が働くようになりますし、そもそも、キャストなどによる型変換の手間を省くことができます。[View data class] には、ビュー スクリプトに関連付けるエンティティ クラスを指定します。</p>
<p>[View content] は、自動生成するビューの種類を選択します。List (一覧)、Details (詳細)、Create (登録)、Edit (編集) から選択できますが、ここでは Address オブジェクトの一覧ページを生成したいので、「List」を選択しておきます。</p>
<p>[Select master page] (マスター ページを選択するか) は、ビューにマスター ページ (共通のレイアウト) を適用するかどうかを決めるためのオプションです。適用するマスター ページは自由に設定することもできますが、今回はプロジェクトがデフォルトで用意している「~/Views/Shared/Site.Master」をそのまま利用します。</p>
<p>[Add] ボタンをクリックすると、「/Views/Address」フォルダーの配下にビュー スクリプトである「Index.aspx」が生成されます。このように、ビュー スクリプトは「/Views/コントローラー名/アクション名.aspx」のようなルールで命名するのが基本です。</p>
<p>コード エディターには、Index.aspx の骨組みとなるコードが表示されます。既に必要な情報はすべてそろっていますので、ここでは表示に不要な一部の列を削除するだけに留めます。太字の部分が削除するコードです (コメントは著者が追加したものなので、入力の必要はありません)。</p>
<div style="margin:2px 0px; padding:5px 5px 0px 5px; background-color:#dedfde">
<p>&lt;%@ Page Title=&quot;&quot; Language=&quot;C#&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&lt;IEnumerable&lt;MvcBeginCs.Models.Address&gt;&gt;&quot; %&gt;</p>
<p>&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;<br>
Index<br>
&lt;/asp:Content&gt;</p>
<p>&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;</p>
<p>&lt;h2&gt;Index&lt;/h2&gt;</p>
<p>&lt;table&gt;<br>
&lt;tr&gt;<br>
&lt;th&gt;&lt;/th&gt;<br>
&lt;th&gt;<br>
AddressID<br>
&lt;/th&gt;<br>
&lt;th&gt;<br>
AddressLine1<br>
&lt;/th&gt;<br>
&lt;th&gt;<br>
AddressLine2<br>
&lt;/th&gt;<br>
&lt;th&gt;<br>
City<br>
&lt;/th&gt;<br>
&lt;th&gt;<br>
StateProvince<br>
&lt;/th&gt;<br>
&lt;th&gt;<br>
CountryRegion<br>
&lt;/th&gt;<br>
&lt;th&gt;<br>
PostalCode<br>
&lt;/th&gt;<br>
<strong>&lt;th&gt;</strong><br>
<strong>rowguid</strong><br>
<strong>&lt;/th&gt;</strong><br>
&lt;th&gt;<br>
ModifiedDate<br>
&lt;/th&gt;<br>
&lt;/tr&gt;</p>
<p>&lt;%-- (1) モデルの内容を順に出力 --%&gt;<br>
&lt;% foreach (var item in Model) { %&gt;<br>
<br>
&lt;tr&gt;<br>
&lt;td&gt;<br>
&lt;%-- (2) 編集、詳細画面へのリンクを生成。 <br>
(ただし、現在はリンク先がないので移動できません) --%&gt;<br>
&lt;%= Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, new { id=item.AddressID }) %&gt; |<br>
&lt;%= Html.ActionLink(&quot;Details&quot;, &quot;Details&quot;, new { id=item.AddressID }) %&gt;<br>
&lt;/td&gt;<br>
&lt;td&gt;<br>
&lt;%= Html.Encode(item.AddressID) %&gt;<br>
&lt;/td&gt;<br>
&lt;td&gt;<br>
&lt;%= Html.Encode(item.AddressLine1) %&gt;<br>
&lt;/td&gt;<br>
&lt;td&gt;<br>
&lt;%= Html.Encode(item.AddressLine2) %&gt;<br>
&lt;/td&gt;<br>
&lt;td&gt;<br>
&lt;%= Html.Encode(item.City) %&gt;<br>
&lt;/td&gt;<br>
&lt;td&gt;<br>
&lt;%= Html.Encode(item.StateProvince) %&gt;<br>
&lt;/td&gt;<br>
&lt;td&gt;<br>
&lt;%= Html.Encode(item.CountryRegion) %&gt;<br>
&lt;/td&gt;<br>
&lt;td&gt;<br>
&lt;%= Html.Encode(item.PostalCode) %&gt;<br>
&lt;/td&gt;<br>
<strong>&lt;td&gt;</strong><br>
<strong>&lt;%= Html.Encode(item.rowguid) %&gt;</strong><br>
<strong>&lt;/td&gt;</strong><br>
&lt;td&gt;<br>
&lt;%= Html.Encode(String.Format(&quot;{0:g}&quot;, item.ModifiedDate)) %&gt;<br>
&lt;/td&gt;<br>
&lt;/tr&gt;<br>
<br>
&lt;% } %&gt;</p>
<p>&lt;/table&gt;</p>
<p>&lt;p&gt;<br>
&lt;%= Html.ActionLink(&quot;Create New&quot;, &quot;Create&quot;) %&gt;<br>
&lt;/p&gt;</p>
<p>&lt;/asp:Content&gt;</p>
</div>
<p>View メソッド経由で渡されたモデルにアクセスするには、(1) のように Model プロパティにアクセスします。先述したように、ビュー スクリプトには Address オブジェクトの集合が渡されているはずなので、ここでは foreach 文で、順に Address オブジェクトを取り出して、その内容を出力しています。foreach ブロックの中では、変数 item を介して、item.Name のような形式で、オブジェクトのプロパティにアクセスできます。</p>
<p>ビュー スクリプト において、変数や式の内容を表示するには、以下のように記述します。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">&lt;%= Html.Encode(変数 / 式) %&gt;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>&lt;%= Html.Encode(...) %&gt;は、与えられた式の値を HTML エスケープしなさい、という意味です。つまり、変数 / 式に含まれる「&lt;」や「&gt;」のような文字は、「&lt;」「&gt;」のような文字列にエスケープ処理されます。</p>
<p>データベースから取得した値をはじめとして、動的に出力する文字列は、このように&lt;%= Html.Encode(...) %&gt; でエスケープ処理するのを忘れないようにしてください。エスケープ処理の漏れは、クロスサイト スクリプティングと呼ばれる典型的な脆弱性の原因となる可能性があります。</p>
<p>(2) の Html.ActionLink メソッドにも要注目です。ActionLink メソッドは、ビュー ヘルパーの一種です。ビュー ヘルパーとは、ビュー スクリプトで利用できるメソッドのことで、フォーム要素やハイパーリンクの生成、エンコードなどの機能を提供します。ASP.NET MVC のビュー開発では、ビュー ヘルパーを利用することでビューを効率的に開発できます。(2) の例では、ActionLink メソッドにリンク テキスト、リンク先のアクション名、パラメーター情報の順に引き渡すことで、最終的に、以下のようなアンカー
 タグを生成します。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><code class="csharp">&lt;a href=&quot;/Address/Edit/11390&quot;&gt;Edit&lt;/a&gt; |
&lt;a href=&quot;/Address/Details/11390&quot;&gt;Details&lt;/a&gt;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p style="margin-top:20px"><a href="#top"><img src="9050-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="07">7. ASP.NET MVC アプリケーションの実行</h2>
<p>それでは Visual Studio で [F5] キーを押して、いま作成したアプリケーションを実行してみましょう。初回起動時には、[デバッグが無効です] ダイアログが表示されますので、「デバッグを有効にするために Web.config ファイルを変更する」を選択し、[OK] ボタンをクリックしてください。開発サーバーと Web ブラウザーが起動し、以下のようにデフォルトで用意されたトップ画面が表示されます。</p>
<p><img src="9051-image.png" alt=""></p>
<p><strong>図 10 ASP.NET MVC 2 Web Application プロジェクトのデフォルトのトップ画面</strong></p>
<p>Web ブラウザーのアドレス欄から「http://localhost:49870/Address/Index」のように入力してみてください (ポート番号は環境によって異なります)。冒頭の図 1 のような結果が得られれば、サンプルは正しく動作しています。</p>
<p>ASP.NET MVC では、このように「/コントローラー名/アクション名」で URL が決まります。ここまでに紹介してきた命名規則に従うことで、特別な設定ファイルやコードを記述しなくても、必要なコンポーネントが芋づる式に呼び出されるわけです。</p>
<p style="margin-top:20px"><a href="#top"><img src="9052-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="08">8. おわりに</h2>
<p>ASP.NET MVC による開発の手続きは、従来の ASP.NET のそれとは異なります。しかし、データ モデルの作成に始まり、これにアクセスするコントローラー (アクション メソッド) を作成し、ビュー スクリプトを定義するという流れは定型的なもので、初学者の方にもごく親しみやすいものです。まずは、本稿で示した ASP.NET MVC 開発の基本的な流れを理解してください。</p>
<hr>
<div>
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/asp.net/" target="_blank"><img src="-ff950935.asp_net_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="ASP.NET デベロッパーセンター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; 10 行でズバリ!! サンプル コード集 (<a href="http://msdn.microsoft.com/ja-jp/netframework/ee708289" target="_blank">C#</a> |<a href="http://msdn.microsoft.com/ja-jp/netframework/ee708290" target="_blank">VB</a>)
</li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっと ASP.NET の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/asp.net" target="_blank">
ASP.NET デベロッパーセンターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
</div>
</div>
