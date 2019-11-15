# 10 行でズバリ !! 接続型のデータ アクセス (ADO.NET) (VB)
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2008
- ADO.NET
- Visual Studio 2010
## Topics
- 10 行でズバリ!!
- データ アクセス開発
## Updated
- 02/11/2011
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
<div>
<div class="Clear"></div>
</div>
<div>
<div class="Clear"></div>
</div>
<p>更新日: 2009 年 12 月 18 日</p>
<div>
<table border="0" cellspacing="0" cellpadding="5" bgcolor="#e5f1f8" style="margin-bottom:10px">
<tbody>
<tr>
<td style="padding:10px 10px 10px 10px">
<div style="text-align:left; float:left; margin:0pt 9px 9px 0pt"><img src="12614-image.png" alt=""></div>
C# の内容はこちらに掲載しています。<a href="/ja-jp/10-ADONET-C-4d84bfef">10 行でズバリ !! 接続型のデータ アクセス (ADO.NET) (C#)</a></td>
</tr>
</tbody>
</table>
</div>
<h2><img src="12615-image.png" alt=""> このコンテンツのポイント</h2>
<div>
<ul>
<li>非接続型データ アクセスの基本的なプログラミング </li><li>接続文字列の取得方法 </li><li>SqlConnection、SqlCommand、SqlDataReader クラスの使い方 </li></ul>
</div>
<h2><img src="12616-image.png" alt=""> 今回紹介するコード</h2>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Imports <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a>

Module Module1

    Sub Main()

        Dim connStr As String = &quot;Data Source=.\SQLEXPRESS;AttachDbFilename=C:\SampleDB\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True&quot;

        Dim conn As New SqlConnection(connStr)
        conn.Open() ' 接続のオープン

        Dim sqlQuery As String = &quot;SELECT SupplierID, Country FROM Suppliers&quot;
        Dim cmd As New SqlCommand(sqlQuery, conn) ' コマンドの作成

        Dim reader As SqlDataReader = cmd.ExecuteReader() ' コマンドの実行

        While reader.Read() ' 1 行読み込み
            Console.WriteLine(&quot;SupplierID: {0} - Country: {1}&quot;, reader(&quot;SupplierID&quot;), reader(&quot;Country&quot;))
        End While

        reader.Close() ' リーダーのクローズ
        conn.Close() ' 接続のクローズ

        Console.ReadLine() ' 一時停止用
    End Sub

End Module</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<h2>目次</h2>
<ol>
<li><a href="#01">はじめに</a> </li><li><a href="#02">データベースとコンソール アプリケーションの準備</a> </li><li><a href="#03">接続型データ アクセスの手順</a> </li><li><a href="#04">SqlConnection クラスによる接続の作成</a> </li><li><a href="#05">サーバー エクスプローラーを使った接続文字列の取得</a> </li><li><a href="#06">SqlCommand クラスによるコマンドの作成</a> </li><li><a href="#07">コマンドの実行</a> </li><li><a href="#08">レコード件数の取得</a> </li><li><a href="#09">レコードの更新処理</a> </li><li><a href="#10">SqlDataReader クラスによるレコードの取得</a> </li></ol>
<hr>
<h2 id="01">1. はじめに</h2>
<p>.NET では、<a href="http://msdn.microsoft.com/ja-jp/netframework/ee815795.aspx">非接続型のデータ アクセス</a> (接続を維持せずにデータ処理をおこない、データの取得/反映など、必要に応じてデータベースへ接続を行うスタイル) が主流ですが、もちろん従来からの接続型 (処理開始時に接続を行い、処理後に接続を閉じる) のデータ アクセスも可能です。</p>
<p>接続型データ アクセスには、データベースのオープン、読み書き、クローズを明示的に行うのでプログラムの構造が分かりやすく、更新処理において UPDATE 文や DELETE 文を直接記述して実行できるので手軽である、などの特徴があります。</p>
<p>ここでは接続型データ アクセスを用いたデータベースへの基本的なアクセス方法について、Visual Studio を使ってコードを記述しながら解説していきます。</p>
<p style="margin-top:20px"><a href="#top"><img src="12617-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. データベースとコンソール アプリケーションの準備</h2>
<p>今回はアクセスするデータベースとして、<a href="http://www.microsoft.com/downloads/details.aspx?FamilyId=06616212-0356-46A0-8DA2-EEBC53A68034&displaylang=en" target="_blank">このページ (英語)</a> からダウンロードできる Northwind データベース (NORTHWND.MDF ファイル) を使用します。</p>
<p>また、Visual Studio では、コンソール アプリケーションを作成して、データベースにアクセスするコードを記述していきます。これにはまず Visual Studio を起動し、[ファイル] メニューの [新規作成] から [プロジェクト] をクリックして、[新しいプロジェクト] ダイアログを開きます。そして [プロジェクトの種類] で [Windows] を、[テンプレート] では [コンソール アプリケーション] を選択します。[プロジェクト名] は任意の名前を指定できますが、ここでは「ADOConsoleApplication」としました。</p>
<p><img src="12618-image.png" alt=""></p>
<p><strong>図 1. [新しいプロジェクト] ダイアログでコンソール アプリケーションのプロジェクトを新規作成</strong></p>
<p style="margin-top:20px"><a href="#top"><img src="12619-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. 接続型データ アクセスの手順</h2>
<p>接続型データ アクセスのプログラミングでは、通常、以下の順序で処理を記述していきます。</p>
<ol>
<li>接続の作成 (SqlConnection クラスを使用) </li><li>SQL 文を含んだコマンドの作成 (SqlCommand クラスを使用) </li><li>コマンドの実行 </li><li>レコードの取得 (SqlDataReader クラスを使用) </li></ol>
<p>以降では、これらを順に解説していきます。なお、上記の「Sql」で始まる 3 つのクラスは、すべて <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a> 名前空間に含まれています。</p>
<p>ちなみに、非接続型データ アクセスの場合は Visual Studio にさまざまなウィザードが用意されており多くのコードを自動生成できますが、今回の接続型データ アクセスでは、基本的にウィザードが用意されていませんので、すべてのコードを自分で記述していくことになります。</p>
<p style="margin-top:20px"><a href="#top"><img src="12620-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. SqlConnection クラスによる接続の作成</h2>
<p>まず、SqlConnection クラスを用いて、データベースとの接続をオープンする必要があります。</p>
<p>このための具体的なコードは次のようになります。(<strong>&lt;接続文字列&gt;</strong> の部分については実際には別の文字列が入ります。これについては後述します。) ここでは、処理後に必要な接続のクローズも併せて記述しています。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p><strong>Imports <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a></strong></p>
<p>Module Module1</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;Sub Main()</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Dim connStr As String = &quot;＜接続文字列＞&quot;</strong></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Dim conn As New SqlConnection(connStr)</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>conn.Open() ' 接続のオープン</strong></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>' データベース処理を記述</strong></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>conn.Close() ' 接続のクローズ</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;End Sub</p>
<p>End Module</p>
</div>
<p>実際に Visual Studio で入力した様子を以下に示します。</p>
<p><img src="12621-image.png" alt=""></p>
<p><strong>図 2. Visual Studio でコードを記述</strong></p>
<p><strong>&lt;接続文字列&gt;</strong> の部分には、接続するデータベースの場所や、接続時に使用される認&#35388;情報などを列挙した接続文字列を記述する必要があります。</p>
<p style="margin-top:20px"><a href="#top"><img src="12622-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. サーバー エクスプローラーをー使った接続文字列の取得</h2>
<p>この接続文字列は、Visual Studio のサーバー エクスプローラーを使えば簡単に生成できます。</p>
<p>これにはまず、Visual Studio の [表示] メニューの [サーバー エクスプローラー] を実行して、サーバー エクスプローラーを開きます。そしてサーバー エクスプローラー上で [データ接続] の項目を右クリックして、コンテキスト メニューより [接続の追加] を実行します。</p>
<p><img src="12623-image.png" alt=""></p>
<p><strong>図 3. サーバー エクスプローラーで [接続の追加] を実行</strong></p>
<p>これにより [接続の追加] ダイアログが開きますので、データベース接続に必要な情報を設定します。今回の場合では、次の画面のように、[データ ソース] として「Microsoft SQL Server データベース ファイル」を選択し、[データベース ファイル名] として、NORTHWND.MDF ファイルのパスを指定しています (この例では NORTHWND.MDF ファイルが「C:\SampleDB」フォルダーにあるものとしています)。</p>
<p><img src="12624-image.png" alt=""></p>
<p><strong>図 4. [接続の追加] ダイアログ</strong></p>
<p>画面左下にある [テスト接続] ボタンをクリックすれば、設定した情報で、実際にデータベースにアクセスできるかどうかを試すことができます。</p>
<p>設定が完了したら、右下にある [詳細設定] ボタンをクリックしてください。</p>
<p><img src="12625-image.png" alt=""></p>
<p><strong>図 5. 接続文字列が表示された [詳細プロパティ] ダイアログ</strong></p>
<p>[詳細プロパティ] ダイアログが開きますが、一番下にある「Data Source= ～」の文字列が、いま設定した接続情報を表す接続文字列です。例えば上記の画面では、この文字列は以下のようになっています。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">Data Source=.\SQLEXPRESS;AttachDbFilename=C:\SampleDB\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True</div>
<p>この文字列をコピーし、前述のコード内の <strong>&lt;接続文字列&gt;</strong> の部分に貼り付けます。最終的には、変数 connStr の記述部分は次のようになります。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">Dim connStr As String = &quot;Data Source=.\SQLEXPRESS; ...... 途中省略 ......&quot;</div>
<p>接続文字列が分かれば、上記のダイアログは特に必要ありませんので [キャンセル] ボタンをクリックして閉じてください。あるいは実際に接続を作成すれば、サーバー エクスプローラーを用いてデータベースのスキーマや実際のレコードの内容をチェックできます。</p>
<p style="margin-top:20px"><a href="#top"><img src="12626-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="06">6. SqlCommand クラスによるコマンドの作成</h2>
<p>続いては、データベース上で実行したい SQL 文がセットされた &quot;コマンド&quot; を、SqlCommand クラスを用いて作成します。このとき、いま作成した SqlConneciton クラスのオブジェクトも必要となります。</p>
<p>SqlCommand オブジェクトの作成には、コンストラクタのパラメーターに、実行したい SQL 文と、SqlConneciton オブジェクトを指定します。ここでは、Suppliers テーブルから SupplierID 列と Country 列の値を含んだレコードを取り出す SQL 文を例として用います。</p>
<p>この SqlCommand オブジェクトを作成するためのコードは次のようになります (最終的な全コードは本稿の最後で示しています)。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Dim sqlQuery As String = &quot;SELECT SupplierID, Country FROM Suppliers&quot;
Dim cmd As New SqlCommand(sqlQuery, conn) ' コマンドの作成</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>なお、上記のようにコンストラクタを使用せず、SqlCommand オブジェクトの Connection プロパティや CommandText プロパティから SQL 文の文字列や SqlConneciton オブジェクトの設定をおこなうこともできます。</p>
<p style="margin-top:20px"><a href="#top"><img src="12627-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="07">7. コマンドの実行</h2>
<p>次はいよいよ、いま作成したコマンドを実行します。</p>
<p>上記の SELECT 文のように、実行結果に含まれるレコードが複数ある場合には、SqlCommand オブジェクトで ExecuteQuery メソッドを呼び出しますが、実行結果のタイプによって呼び出すメソッドが異なるので注意をしてください。このコードは次のようになります。これにより、実際にデータベースに SQL 文が送信されます。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Dim reader As SqlDataReader = cmd.ExecuteReader() ' コマンドの実行</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>このコードからも分かるように、ExecuteQuery メソッドの戻り値は複数行のレコードとなるため SqlDataReader クラスのオブジェクトとなりますが、実行結果のタイプによって呼び出すメソッドが異なるので注意をしてください。以降では、SQL 文の実行結果が 1 つの数値や文字列になる場合と、SQL 文の実行結果がない場合、すなわち、UPDATE 文や DELETE 文、INSERT 文などの更新系の実行について先に説明し、上記の SqlDataReader を使用した処理については、この説明の後で後述します。</p>
<p style="margin-top:20px"><a href="#top"><img src="12628-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="08">8. レコード件数の取得</h2>
<p>SQL 文の実行結果が 1 つの数値や文字列だけになることが分かっている場合には、ExecuteScalar メソッドを呼び出してコマンドを実行します。</p>
<p>例えば、Suppliers テーブルのレコード件数を取得したい場合には、コードは次のようになります。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>Imports <a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a></p>
<p>Module Module1</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;Sub Main()</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim connStr As String = &quot;Data Source=.\SQLEXPRESS;AttachDbFilename=C:\SampleDB\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim conn As New SqlConnection(connStr)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Open() ' 接続のオープン</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim sqlQuery As String = &quot;<strong>SELECT Count(*) FROM Suppliers</strong>&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim cmd As New SqlCommand(sqlQuery, conn) ' コマンドの作成</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Dim num As Integer = CType(cmd.ExecuteScalar(), Integer) ' コマンドの実行</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Console.WriteLine(&quot;レコード件数：{0}&quot;, num)</strong></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Close() ' 接続のクローズ</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine() ' 一時停止用<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Sub</p>
<p>End Module</p>
</div>
<p>ExecuteScalar メソッドの戻り値は Object 型ですので、この場合には Integer 型にキャストする必要があります。</p>
<p>Visual Studio で [F5] キーを押してアプリケーションを実行すると、このプログラムの実行結果は次の画面のようになります。</p>
<p><img src="12629-image.png" alt=""></p>
<p>図 6. レコード件数取得プログラムの実行結果</p>
<p style="margin-top:20px"><a href="#top"><img src="12630-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="09">9. レコードの更新処理</h2>
<p>UPDATE 文や DELETE 文、INSERT 文などの実行結果を持たない SQL 文の実行には、ExecuteNonQuery メソッドを使用します。</p>
<p>以下のコードでは、Suppliers テーブルの Country 列の値が「Japan」のレコードに対して、それを「Nihon」に更新する UPDATE 文を発行します。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>Imports System.Data.SqlClien</p>
<p>Module Module1</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;Sub Main()</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim connStr As String = &quot;Data Source=.\SQLEXPRESS;AttachDbFilename=C:\SampleDB\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim conn As New SqlConnection(connStr)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Open() ' 接続のオープン</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim sqlQuery As String = &quot;<strong>UPDATE Suppliers SET Country = 'Nihon' WHERE Country = 'Japan'</strong>&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim cmd As New SqlCommand(sqlQuery, conn) ' コマンドの作成</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Dim num As Integer = cmd.ExecuteNonQuery() ' コマンドの実行</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Console.WriteLine(&quot;処理した件数：{0}&quot;, num)</strong></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Close() ' 接続のクローズ</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine() ' 一時停止用<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Sub</p>
<p>End Module</p>
</div>
<p>ExecuteNonQuery メソッドの戻り値は、実際に処理したレコード件数となります。初期状態では、Country 列の値が「Japan」のレコードは 2 件ありますので、このプログラムの実行結果は次のようになります。</p>
<p><img src="12631-image.png" alt=""></p>
<p><strong>図 7. レコード更新プログラムの実行結果</strong></p>
<p style="margin-top:20px"><a href="#top"><img src="12632-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="10">10. SqlDataReader クラスによるレコードの取得</h2>
<p>それでは最後に、SqlDataReader オブジェクトからのレコードの取得について説明します。</p>
<p>先ほども示した以下のコードにより取得できた SqlDataReader オブジェクトは、SQL 文の実行結果からレコードを読み出すための機能を持っています。この機能は、データベースと接続している状態でのみ利用可能です。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Dim reader As SqlDataReader = cmd.ExecuteReader() ' コマンドの実行</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>実際に、この SqlDataReader オブジェクトからレコードを取得するには、SqlDataReader オブジェクトに対して、さらに Read メソッドを呼び出します。これにより、オブジェクト内に実行結果から 1 レコードが読み込まれます。そして、レコード内の列データを取り出すには、以下のようにインデクサを用います。以下のコードは、取得した最初の 1 レコードの内容を画面に表示します。</p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Dim hasRecord As Boolean = reader.Read() ' 1 行読み込み
Console.WriteLine(&quot;SupplierID: {0} - Country: {1}&quot;, reader(&quot;SupplierID&quot;), reader(&quot;Country&quot;))</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>同じようにして、Read メソッドをもう 1 度呼び出すと、次の 1 レコードを取得できます。ただし、Read メソッドの戻り値が False だった場合には、取得するレコードが存在しなかったことを示します。</p>
<p>このように Read メソッドを使った処理は少々複雑ですが、これは複数のレコードを最もパフォーマンス良く取得するためのデータベースの仕組みによるものだといえます。</p>
<p>SQL 文の実行結果に対して、すべてのレコードを処理する場合には、以下のような While 文で Read メソッドを呼び出すのが一般的です。このプログラムは、取得したすべてのレコードの内容を表示します。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>. . .</p>
<p>Dim sqlQuery As String = &quot;<strong>SELECT SupplierID, Country FROM Suppliers</strong>&quot;<br>
Dim cmd As New SqlCommand(sqlQuery, conn) ' コマンドの作成</p>
<p><strong>Dim reader As SqlDataReader = cmd.ExecuteReader() ' コマンドの実行</strong></p>
<p><strong>While reader.Read() ' 1 行読み込み<br>
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(&quot;SupplierID: {0} - Country: {1}&quot;, reader(&quot;SupplierID&quot;), reader(&quot;Country&quot;))<br>
End While</strong></p>
<p><strong>reader.Close() ' リーダーのクローズ</strong><br>
conn.Close() ' 接続のクローズ</p>
<p>. . .</p>
</div>
<p>Visual Studio で実行すると、実行結果は次のような画面になります。</p>
<p><img src="12633-image.png" alt=""></p>
<p><strong>図 8 取得した全レコードの表示</strong></p>
<p>全部で 29 件のレコードが表示され、先ほど更新した Country = Nihon のレコードが含まれているのも分かります。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img title="Code Recipe" src="http://i.msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; 10 行でズバリ!! サンプル コード集 (<a href="http://msdn.microsoft.com/ja-jp/netframework/ee708289" target="_blank">C#</a> |
<a href="http://msdn.microsoft.com/ja-jp/netframework/ee708290" target="_blank">VB</a>)
</li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっとデータアクセスの情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/data/" target="_blank">
データアクセス デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
