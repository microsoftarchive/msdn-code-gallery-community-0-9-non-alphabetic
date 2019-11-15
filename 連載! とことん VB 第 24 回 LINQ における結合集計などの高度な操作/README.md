# 連載! とことん VB: 第 24 回 LINQ における結合/集計などの高度な操作
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
<style><!-- ﻿.showRatings{border-bottom:silver 1px solid;background-color:#f0f0f0;text-align:left;width:100%;height:28px;vertical-align:bottom;}.showRatings_right{z-index:99;float:right;} ﻿.ShareThisMainPanel{text-align:left;float:left;}.ShareThis_RootButton{cursor:pointer;border:solid
 0 #000;display:inline;margin-top:5px;margin-bottom:15px;margin-right:10px;}.ShareThis_BtnLink{vertical-align:middle;color:#000;font-weight:700;}.ShareThis_RootButton_Image{padding-left:5px;vertical-align:middle;}.ShareThis_ChildRootPanel{top:211px;left:6px;color:#000;width:auto;height:auto;padding:2px;z-index:1000;text-align:left;}.ShareThisBrand_X
 img{vertical-align:bottom;}.TierOneButtons1{border:solid 0 blue;cursor:pointer;min-width:135px;}.tierTwoPanel{border:solid 0 blue;cursor:pointer;min-width:135px;border-top:solid 1px #999;clear:both;width:140px;}.tierTwoHorizontal{border:solid 0 blue;cursor:pointer;float:left;min-width:135px;width:140px;}.tierTwoRowPanel{border:solid
 0 blue;cursor:pointer;float:left;min-width:135px;display:inline;}.buttonPanel{border-bottom:solid 0 orange;padding:4px 0 4px 4px;margin-bottom:2px;vertical-align:top;float:left;}.buttonPanelHyperLink{margin-left:4px;}.iconsOnPanel{height:16px;width:16px;vertical-align:bottom;}.STMain{text-align:left;float:left;}
 ﻿.VCR_Container{position:relative;}.VCR_GroupLabel{color:#333;font-weight:bold;padding:5px 0 1px;}.VCR_GroupLabel:first-child{padding-top:0;}.VCR_Label{border-left:1px solid #fff;border-bottom:1px solid #fff;color:#06d;cursor:pointer;margin:2px 0 0 0;padding:1px
 0 2px 4px;}.VCR_Label_Focussed{background:#e3e3e3 url('../../images/common.png') 0 -74px repeat-x;border-left:1px solid #c2c2c2;border-bottom:1px solid #c2c2c2;color:#f60;}.VCR_Label_Selected{background:#e3e3e3 url('../../images/common.png') 0 -74px repeat-x;border-left:1px
 solid #c2c2c2;border-bottom:1px solid #c2c2c2;}.VCR_ContentItem{background-color:#fff;display:none;padding-left:12px;overflow:hidden;position:absolute;top:13px;right:0;bottom:0;left:0;}.VCR_CheckBox{cursor:pointer;position:absolute;top:0;right:4px;}.VCR_CheckBoxImage{background:#260859
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
 div.ItemCont{background:#f3f3f7;margin-bottom:25px;margin-right:29px;float:left;}div.HeadlineNews a.Item{display:inline-block;height:206px;overflow:hidden;margin-bottom:5px;}div.HeadlineNews h2.NewsTitle{padding:0 0 10px 4px;font-weight:100;}div.HeadlineNews
 h2.NewsTitle span.Last{font-family:"Segoe UI Light","Segoe UI","Lucida Grande",Verdana,Arial,Helvetica,sans-serif;font-weight:200;}div.HeadlineNews span.Image{display:block;overflow:hidden;margin-bottom:6px;}div.HeadlineNews span.Title{display:block;padding:5px
 5px 6px 5px;font-size:120%;}div.HeadlineNews span.Description,div.HeadlineNews span.Description:hover,div.HeadlineNews span.Description:active{display:block;padding:0 5px 4px 5px;color:#000;line-height:16px;}div.HeadlineList{display:inline-block;margin-bottom:10px;}div.HeadlineList
 div.Items{display:inline-block;}div.HeadlineList div.ItemsWithHeaderImage{padding:13px 21px 0 13px;}div.HeadlineList a.Item{width:100%;}div.HeadlineList a.Item span{display:inline-block;}div.HeadlineList div.Items .ShareThis2Cont{margin-bottom:20px;}div.HeadlineList
 div.Items .ShareThis2{float:right;position:relative;top:-4px;}div.HeadlineList a.Item .Description,div.HeadlineList a.Item span.Description:hover,div.HeadlineList a.Item span.Description:active{display:inline-block;color:#000;margin-bottom:10px;}.FooterLinks{padding:6px
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
<p>更新日: 2010 年 5 月 28 日</p>
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
<li><a href="#01">はじめに</a> </li><li><a href="#02">クエリ式での基本的な結合</a> </li><li><a href="#03">3 つ以上のテーブルの結合</a> </li><li><a href="#04">標準クエリ演算子での基本的な結合</a> </li><li><a href="#05">結合や集計などの複数の操作の組み合わせ～クエリ式の見方のコツ～</a> </li></ol>
<hr>
<h2 id="01">1. はじめに</h2>
<p>今回は、前回取り上げた基本的なクエリ式をより発展させて、結合や集計などのバリエーションについて取り上げます。</p>
<p>なお、今回もクエリ式のキーワードや構文をいくつか扱いますが、ここでは代表的な操作の書き方と特徴について扱っています。なお、構文のラインアップなどの全体像や詳細を把握するには、以下のURLが参考になります。(標準クエリ演算子の一覧と、各演算子に対応するクエリ構文の対応表が掲載されています。(2010 年 5 月現在) )</p>
<p><a href="http://msdn.microsoft.com/ja-jp/library/bb882642" target="_blank">MSDN: Query Expression Syntax for Standard Query Operators</a></p>
<p style="margin-top:20px"><a href="#top"><img src="16905-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. クエリ式での基本的な結合</h2>
<p>まず、次のサンプル コードを用いて、クエリ式の基本的な結合操作について確認します。典型的な結合では、データベース上の 2 つの表 (テーブル) を使用しますが、次のサンプルでは、メモリ上に 2 つのコレクションを用意して、これを表に見立てて結合することにします。表に含まれる 1 件ごとのデータ (行) に当たるものは、コレクション内の 1 つの要素です。(以下のサンプルコードを実行するには、Windows フォーム アプリケーション プロジェクトを作成し、ボタン 1 つ、リストボックス 1 つをフォームに貼り付け、下記の通りボタンのイベント
 ハンドラを生成します。)</p>
<p><strong>例 1. Join 句での基本的な結合</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>Public Class Form1</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private customers As New List(Of Customer) From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[1]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{New Customer(&quot;ERNSH&quot;, &quot;Ernst Handel&quot;),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New Customer(&quot;QUICK&quot;, &quot;QUICK-Stop&quot;),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New Customer(&quot;SAVEA&quot;, &quot;Save-a-lot Markets&quot;)}</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private orders As New List(Of Order) From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[2]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{New Order(100, &quot;ERNSH&quot;, #4/12/2010#),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New Order(101, &quot;QUICK&quot;, #4/17/2010#),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New Order(102, &quot;ERNSH&quot;, #5/10/2010#)}</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private Sub Button1_Click(...) Handles Button1.Click &larr;Clickイベントハンドラ</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim query1 = <strong>
From o In orders</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[3]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Join c In customers On o.CustomerID Equals c.CustomerID</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Select o.OrderID, o.OrderDate, c.CompanyName</strong></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For Each d In query1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[4]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListBox1.Items.Add(d.OrderID &amp; &quot; &quot; &amp; d.OrderDate &amp; &quot; &quot; &amp; d.CompanyName)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub</p>
<p>End Class</p>
<p>Public Class Customer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[5]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property CustomerID As String<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property CompanyName As String<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Sub New(ByVal id As String, ByVal name As String)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerID = id<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompanyName = name<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
End Class</p>
<p>Public Class Order&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;[6]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property OrderID As Integer<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property CustomerID As String<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property OrderDate As Date<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Sub New(ByVal id As Integer, ByVal custId As String, ByVal dt As Date)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OrderID = id<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerID = custId<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OrderDate = dt<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
End Class</p>
</div>
<p>[1] と [2] には、Customer オブジェクトのコレクション (変数 customers) と Order オブジェクトのコレクション (変数 orders) を用意しました。この 2 つのコレクションを表に見立て、それぞれを顧客テーブルと注文テーブルと考えてください。(「表」の定義に相当する Customer クラスと Order クラスが [5] と [6] にあり、各クラスに定義されたプロパティが「列」に相当します。)</p>
<p>[3] の太字部分のクエリ式が、この 2 つのテーブルを結合するものです。ここでは、注文データ (Order クラス) と顧客データ (Customer クラス) の両方に含まれる顧客 ID (CustomerID プロパティ) をキーとして結合しています。この式の意味を考えてみましょう。</p>
<p>まず、[3] のクエリ式の1行目 (From ... In ...) は、前回取り上げたクエリ式と同じであり、この部分だけなら 1 つのテーブル (ここでは orders テーブル) の全件を表します。これに他のテーブルを結合したい場合には、続けて 2 行目 ( Join ... On ...) のように書きます。Join の直後には、結合したいテーブルが「変数定義 In データソース」の形式で記述されます。ここでは結合する「データソース」は顧客テーブル (customers) であり、その要素を変数
 (変数定義) c であらわしています。</p>
<p>さらに、On キーワードの後ろには、結合の際にそれぞれのテーブルの行を照合する際の結合用のキーを指定します。ここではキーとして、注文テーブルの顧客 ID (o.CustomerID) と顧客テーブルの顧客 ID (c.CustomerID) を指定しており、両者が一致する行同士が結合します。ここでは一致すること(等しいこと)を表す表記が Equals キーワードである点に注意してください。言語仕様上、等号 (＝) は使用できません。</p>
<p>その後、Select 句による整形の書き方は、前回と同様ですので、特に問題はないでしょう。実際にプログラムを実行し、フォーム上のボタンをクリックしてすると、結合結果として次のように表示されます。</p>
<p><strong>図 1. 注文テーブル (orders) と顧客テーブル (customers) の結合結果</strong></p>
<p><img src="16906-image.png" border="0" alt=""></p>
<p style="margin-top:20px"><a href="#top"><img src="16907-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. 3 つ以上のテーブルの結合</h2>
<p>上記で見たように、基本的な考えとしては、&quot;Join ... On ...&quot; を追加することで、Join キーワードの後のデータと結合します。さらにテーブルを結合したい場合は、結合したいテーブルの数だけ、この 2 行目の Join 句の記述を追加すればよいのです。例えば、今回のクエリ式で、さらに顧客テーブルの郵便番号列 (ZipCode) をキーにして、郵便番号テーブル (zcodes) と結合したいなら、次のように追加します(太字部分)。</p>
<p><strong>例 2. 3 つのテーブルの結合</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim query1 = From o In orders<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Join c In customers On o.CustomerID Equals c.CustomerID<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Join z In zcodes On c.ZipCode Equals z.ZipCode</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select o.OrderID, o.OrderDate, c.CompanyName, z.AreaName</p>
</div>
<p>この例では、最終行で Select 句を記述して結合結果を整形していますが、この Select 句を書かずに、さらに Join 句を続けて別のテーブルを結合できます。また、この Select 句で整形した後に、さらに Join 句を続けて結合することもできます。</p>
<p style="margin-top:20px"><a href="#top"><img src="16908-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. 標準クエリ演算子での基本的な結合</h2>
<p>簡単な結合であれば前述のクエリ式で記述すれば十分ですが、ここで、同様の結合を標準クエリ演算子 (Join メソッド) で直接表現する方法を確認しましょう。次は、標準クエリ演算子を直接使用して、前述の例 1 の [3] のクエリ式と同等の結合を記述した例です。</p>
<p><strong>例 3. 標準クエリ演算子での基本的な結合</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim query2 = orders.Join(customers,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Function(o) o.CustomerID,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Function(c) c.CustomerID,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Function(o, c) New With {o.OrderID, o.OrderDate, c.CompanyName})</p>
</div>
<p>例 1 の [3] のクエリ式の最初の In キーワードの後ろに記述されたデータソースである orders オブジェクト (注文テーブル) に、Join メソッドを呼び出します。一方、結合相手となる customers オブジェクト (顧客テーブル) は、Join メソッドの 1 番目の引数になります。</p>
<p>結合するために使用するキーの情報 (&quot;On o.CustomerID Equals c.CustomerID&quot;) は、&quot;o.CustomerID&quot; と &quot;c.CustomerID&quot; に分解され、それぞれ 2 番目と 3 番目の引数にラムダ式として渡されます。</p>
<p>Join メソッドの 4 番目の引数では、例 1 の [3] の Select 句に相当する部分をラムダ式で記述して渡します。このラムダ式は、結合すべき行として仮引数に受け取った注文データ (o) と顧客データ (c) を元に、OrderID、OrderDate、CompanyName の 3 つのプロパティからなる匿名クラスが作られます。ここで注意すべきは、このように、クエリ式の Select 句が、独立した Select メソッドの呼び出しにならないという点です。クエリ式で記述された句が、同じメソッド名の標準クエリ演算子にならない場合もあります。</p>
<p>なお、例 1 のクエリ式で Select 句を書かなかった場合は、結合した 1 つの行は、注文データを表す o と顧客データを表す c の 2 つのデータをプロパティに持つオブジェクトになります。注文データの列 (OrderID, OrderDate, など) や顧客データの列 (CustomerID, CompanyName, など) は、これらの 2 つのプロパティの子プロパティになるので注意してください。これを例 3 の Join メソッドの 4 番目の引数として表わす場合は、次のようになります。</p>
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><pre style="padding-bottom:5px"> Function(o, c) New With { o, c }</pre>
</pre>
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>また、紙面の都合で説明の詳細は割愛しますが、前項で触れた例2のように Join 句が 2 つ続く場合は、標準クエリ演算子では次の例 4 のようになります。基本的な考え方としては、1 つ目の Join 句 (Join メソッド呼び出し) の後に、Select 句で加工せずに、次の Join 句 (Join メソッド) の呼び出しが続くということです。余力がある方は、このメソッド呼び出しの記述の意味を吟味してみてください。</p>
<p><strong>例 4. 標準クエリ演算子 (Join メソッド) で 2 回結合を行う</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim query2 = orders.Join(customers,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Function(o) o.CustomerID,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Function(c) c.CustomerID,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Function(o, c) New With { o, c }) _<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Join(zcodes,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Function(w) w.c.ZipCode,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Function(z) z.ZipCode,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Function(w, z) New With { w.o.OrderID, w.o.OrderDate,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;w.c.CompanyName,
 z.AreaName }</p>
</div>
<div style="margin:10px 0; padding:10px 10px 0 10px; background-color:#efefef; border:solid 1px #333333">
<p><strong>Note:</strong> ここでは、データベースの代わりに、メモリ上のコレクションの結合について取り上げていますが、LINQ を使用して SQL Server 上のテーブルを結合する場合も同様です。違いは、In キーワードの後に来る対象データとなるオブジェクトが、データベースを表す専用のオブジェクト (DataContext) になる点です。例えば、例 1 と同じクエリ式で、SQL Server の orders テーブルと customers テーブルとを結合する場合は、次のようになります。(太字部分が例
 1 と異なる点です。)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim query1 = From o In
<strong>db.orders</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Join c In
<strong>db.customers</strong> On o.CustomerID Equals c.CustomerID<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select o.OrderID, o.OrderDate, c.CompanyName</p>
<p>DataContext オブジェクトは LINQ to SQL 固有のオブジェクトの 1 つです。この LINQ to SQL の機能や操作については、次回説明します。</p>
</div>
<p style="margin-top:20px"><a href="#top"><img src="16909-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. 結合や集計などの複数の操作の組み合わせ～クエリ式の見方のコツ～</h2>
<p>最後に、さらに集計 (グループ化) を行うクエリ式を確認しましょう。また、これ以外にもクエリ式の操作は様々なものがあるので、他のクエリ式でも応用が効くように、複数の操作を伴うクエリ式の見方のコツを説明したいと思います。</p>
<p>次の例 5 は、結合と集計などの複数の操作を行うクエリ式の例です。今回は、例 1 のコードに対して、さらに注文明細データである OrderDetail クラス (下記の [9] の部分) と、そのテーブルに相当する orderDetails コレクション (下記の [1] の部分) を追加しました。この例では、[2] から [8] までが、1 つのクエリ式です。</p>
<p><strong>例 5. 結合と集計を行う複数の操作</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>Public Class Form1</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: (省略)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private orderDetails As New List(Of OrderDetail) From &larr; [1]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{New OrderDetail(100, 110), New OrderDetail(100, 120),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New OrderDetail(101, 200), New OrderDetail(102, 300)}</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private Sub Button1_Click(...) Handles Button1.Click &larr;Clickイベントハンドラ</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim query1 = <strong>
From o In orders</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;
 [2]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&nbsp;Join d In orderDetails On o.OrderID Equals d.OrderID</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr; [3]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Select o.CustomerID, d.Price</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;
 [4]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Order By CustomerID Ascending</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;
 [5]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Group By CustomerID Into Kensu = Count(), Gokei = Sum(Price)</strong> &larr; [6]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Join c In customers On CustomerID Equals c.CustomerID</strong> &larr; [7]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Select c.CompanyName, Kensu, Gokei</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr;
 [8]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For Each r In query1<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListBox1.Items.Add(r.CompanyName &amp; &quot; &quot; &amp; r.Kensu &amp; &quot; &quot; &amp; r.Gokei)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub</p>
<p>End Class</p>
<p>Public Class OrderDetail&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&larr; [9]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property OrderID As Integer<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property Price As Decimal<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Sub New(ByVal id As Integer, ByVal pr As Decimal)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OrderID = id<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Price = pr<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
End Class</p>
</div>
<p>基本的な考え方は、クエリ式に 1 つの句を追加すると、その前に記述されたデータソースが、追加された句によって加工されると考えてください。つまり、先頭行の [2] に対して、順に [3]、[4]、. . . と句を追加することで、どんどんデータが加工されていくことになります。</p>
<p>となると、クエリ式を理解できるようになるには、追加する際の &quot;ひとかたまり&quot; の句の単位を知っておく必要があります。例えば、この例の [2] の &quot;From ... In ...&quot; は、orders というデータソースを表すためのまとまった単位です。また、[3] の &quot;Join ... On ... &quot; がまとまりの単位であり、&quot;On ...&quot; だけが単体で現れることはありません。</p>
<p>この例の [4] の時点では、顧客 ID (CustomerID) 列と価&#26684; (Price) 列からなる結合テーブルになっています。(この結合テーブルには、同一顧客の異なる注文もあるので、CustomerID 列の値が同じ行も複数あります。これをあとで、同一顧客ごとに集約します。)</p>
<p>さらに [5] では、Order By 句を使用し、By キーワードの後の顧客 ID をソート キーにして、 [4] までの結果をソートしています。</p>
<p>そして、[6] は [5] の結果を集計 (グループ化) します。&quot;Group By ... Into ...&quot; でひとまとまりと考えてください。By キーワードの後の列が、集計のためのキーです。ここでは、同一顧客ごとに (同じ CustomerID の値ごとに)、1 行の集計行にまとめています。(この集計キー(CustomerID)そのものも、集計行の列になります。) このIntoキーワードの後ろには、集計行に追加される列を書きます。ここに記述された Count や Sum は集計のため演算子 (集計演算子)
 です。Count() は、1 つの集計行にまとめられた件数 (元の行数) を表し、Sum はその引数に記述された列や式の合計を、集計行単位で算出します。ここでも、「名前 = 集計演算子」のように書くことで、これらの集計列に名前を付けることができます。ここでは、Kensu 列と Gokei 列になります。最終的には、この &quot;Group ... Into ...&quot; によって生成される集計行の列構成は、順に CustomerID、Kensu、および Gokei になります。</p>
<p>さらに [7] では、&quot;Join ... On ...&quot; によって customers テーブルを [6] の集計結果のテーブルに結合します。そして最後に、[8] の Select 句で整形します。</p>
<p>以上、今回は結合にまつわる記述方法や、複数の操作を行うクエリ式の基本的な見方のコツなどを取り上げました。これらの知識があれば、他の操作を伴う別の句が登場しても、もう難しいことはないでしょう。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank"><img src="http://i.msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/netframework/" target="_blank"><img src="http://i.msdn.microsoft.com/ff950935.netframework_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt=".NET Framework デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
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
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
</div>
