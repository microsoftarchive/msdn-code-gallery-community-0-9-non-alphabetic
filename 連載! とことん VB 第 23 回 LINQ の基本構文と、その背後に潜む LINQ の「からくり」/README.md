# 連載! とことん VB: 第 23 回 LINQ の基本構文と、その背後に潜む LINQ の「からくり」
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
<p>更新日: 2010 年 5 月 21 日</p>
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
<li><a href="#01">はじめに</a> </li><li><a href="#02">基本的なクエリ式</a> </li><li><a href="#03">クエリ結果(クエリ変数)の型</a> </li><li><a href="#04">匿名型の利用</a> </li><li><a href="#05">標準クエリ演算子の直接的な呼び出し</a> </li></ol>
<hr>
<h2 id="01">1. はじめに</h2>
<p>この一連の記事では、統合言語クエリ (LINQ: Language-Integrated Query) の理解を深めるための関連知識として、ジェネリックや拡張メソッド、ラムダ式について取り上げました。そして、今回から 4 回に渡り、いよいよ、これまで説明した知識をベースとして、LINQ の構文や関連するライブラリについて解説します。(これまでに説明した「型推論」、「匿名型」、「拡張メソッド」、「ラムダ式」などの概念を理解した上で、読み進めてください。)</p>
<p>そもそも、LINQ とは様々な種類の異なるデータに一様な方法でアクセスするためのテクノロジです。その実体は、Visual Basic の構文やライブラリとして提供されます。これらの中で、今回は、構文としての基本事項を改めて振り返り、それに関連する注意点などについて取り上げます。</p>
<p>今後は LINQ を使う機会もますます増えて来ることでしょう。今のうちに、しっかりマスターしておきましょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="16898-image.png" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. 基本的なクエリ式</h2>
<p>まず、データソースに対してクエリを行う「クエリ式」の書き方について取り上げます。基本的なクエリ式にも様々なバリエーションがあり、一部を見落としてしまうことがあるかも知れません。この点もふまえ、基本的な構文を改めて確認してみましょう。</p>
<p>次の例 1 は基本的なクエリ式を使用した例です。(このサンプルコードを実行するには、Windows フォームアプリケーションを作成し、フォームに 1 つのボタンと 1 つのリストボックスを貼り付けた後、このサンプルコードと同じになるよう修正や追加を行ってください。)</p>
<p><strong>例 1. 基本的なクエリ式</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>Public Class Form1</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private Sub Button1_Click(...) Handles Button1.Click &larr;Clickイベントハンドラ</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim data() As Integer = {200, 500, 100, 300, 600, 400} &larr;[1]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim query1 = <strong>
From d In data Where d &lt;= 300 Select d</strong> &larr;[2]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For Each d As Integer In query1 &larr;[3]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListBox1.Items.Add(d)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub</p>
<p>End Class</p>
</div>
<p>ここでは簡単にするため、[1] に定義された Integer 型の配列 data に対して、クエリ操作を行います。[2] の太字部分が、この配列に対してクエリ操作を行うクエリ式です。ここでは、値が 300 以下の要素を抽出しています。クエリ式は、文字通り「抽出結果という値を求める式」であり、式自体が値を表すので、[2] にあるように変数 (ここでは変数 query1) に代入できます。</p>
<p>このクエリ式が返す結果を代入した変数は「クエリ変数」と呼ばれています。論理的には、クエリ変数はクエリ結果 (抽出結果の要素集合) とみなすことができます。しかし、厳密にいうと、実は、クエリ変数にクエリ式を代入しただけでは (上記の [2] を実行しただけでは)、実際のクエリ操作は実行されていません。いつ実行されるかは、データソースやクエリ式の書き方に依存しますが、一般に LINQ では実際に要素を参照するまではクエリ操作が保留されます。これを「遅延実行」と呼びます。この例でも、クエリの書き方によって実行のタイミングが若干異なるのですが、少なくも
 [3] の For Each ループを使用してクエリ結果 (クエリ変数) から実際に要素を参照するまでは、クエリが実行されないと考えておいてください。</p>
<p>また Visual Basic では、原則として 1 つの式や 1 つのステートメントを書くとき、途中で改行せずに 1 行に書く必要がありますが (改行をおこなうには _ (アンダーバー) を使用する必要がありますが)、Visual Basic 2010 の新機能として、行の継続が想定されるいくつかの構文では、途中改行が認められるようになりました。よって、次の例 2 のようにクエリ式を 2 行に渡って記述しても有効な構文となります (1 行目の末尾に継続を表す記号である「アンダーバー」を書く必要はありません)。特にクエリ式は長くなりがちです。このような自然な改行によって、可読性も向上するでしょう。</p>
<p><strong>例 2. クエリ式の暗黙的な行継続 (Visual Basic 2010 から)</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
&nbsp;&nbsp;&nbsp;&nbsp;Dim query1 = <strong>From d In data</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Where d &lt;= 300 Select d</strong></div>
<p>次に、このクエリ式の意味を考えてみましょう。</p>
<p>クエリ操作の対象となるデータソース (データの集合) は、In キーワードの後ろに記述されます。また、その集合の要素 1 つを表す変数定義が d になります。よって、次のような For Each ループと同じ構造と考えてよいでしょう。</p>
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;d&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;data&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>この変数 d はクエリ式の中だけで利用されるローカル変数であり、Where キーワード以降で使用されています。そして、Where 句には抽出条件を書き (ここでは要素 d が 300 以下)、Select 句には抽出した要素の形式を指定します。</p>
<p>Select 句では上記の例のように単に「Select d」と書けば、元の要素の形のままとなり、抽出結果は、200、100、および 300 という値の集合となります。ただし、構文として有効な式であれば何でも書けるので、次のように書くことも可能です。</p>
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Select</span>&nbsp;d&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>&nbsp;<br><span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">CStr</span>(d)&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>前者では、最終的なクエリ結果は、各要素に 1 が加算され、201、101、301 となります。後者は、各要素が String 型に変換されます。</p>
<p>なお、例 1 や例 2 のように「Select d」と書く場合は、抽出結果の要素は特に加工しないので、次のように Select 句を省略しても同じです。このような省略もよくあるので、書き方に慣れておいてください。(実は、厳密にいうと、この例 3 の省略形のほうが、例 1 や例 2 と比較して、オーバーヘッドが少なくなる場合があるのです。これについては、後述します。)</p>
<p><strong>例 3. Select 句の省略</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
&nbsp;&nbsp;&nbsp;&nbsp;Dim query1 = <strong>From d In data Where d &lt;= 300</strong></div>
<p style="margin-top:20px"><a href="#top"><img src="16899-image.png" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. クエリ結果(クエリ変数)の型</h2>
<p>クエリ変数 (例 1 の変数 query1) の型は、IEnumerable(Of T) 型 (または、その派生型) であり、コレクションを表すインターフェイスです。実際は、使用するクエリ式やデータソース (今回の場合、データソースは整数の集合です) に応じて呼び出されるライブラリが異なるため、これによって型が決まります。しかし、コンパイラが型推論によって型を判別できるので、明示的に As 句を書く必要もなく、クエリ変数の型のことで悩むことはないでしょう。</p>
<p>また、既に触れたように、クエリ変数はクエリ結果の要素の &quot;論理的なコレクション&quot; であり、型パラメータ T の部分は、要素の型になります。例 1 の [2] のクエリ式であれば、Integer 型の要素を返すので、クエリ変数は IEnumerable(Of Integer) 型です。</p>
<p>型パラメータ T の部分は、Select 句に記述された要素の形式に依存します。よって、Select 句の書き方によってクエリ変数の型が異なるので、同じデータソースに対するクエリ式であっも、同一のクエリ変数の使い回しが出来るとは限らないので注意してください。</p>
<p>例えば以下の例 4 では、3 つのクエリ式を同一のクエリ変数に代入する簡単な実験をしています。</p>
<p><strong>例 4. Select 句による型の違い</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>Dim query1 = From d In data Where d &lt;= 300 &larr;[1]<br>
query1 = From d In data Where d &gt; 100 Select d &larr;[2]<br>
query1 = From d In data Where d &gt; 100 Select String.Format(&quot;{0}&quot;, d) &larr;[3]</p>
</div>
<p>上記では、[1] で変数を定義して、この時点で型推論によってクエリ変数 query1 の型が決まり、Integer 型の要素を返すので、クエリ結果は IEnumerable(Of Integer) 型です。同様に [2] も、Integer 型要素を返すので、同一のクエリ変数 query1 を流用できます。しかし、[3] は要素を文字列に整形しているので、IEnumerable(Of String) です。既定の設定ではコンパイルオプションが Option Strict Off なので [3] はコンパイルエラーとして発覚しませんが、これは実行時にエラーになります。(Option
 Strict On に設定すると、[3] では型が合わずコンパイルエラーになります。)</p>
<p>なお、Select 句の典型的な書き方の中には、コンパイラによって新しい型 (匿名型) が自動生成され、この新しい型が IEnumerable(Of T) の型パラメータ T の部分になる場合もあります。この点を次に確認しましょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="16900-image.png" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. 匿名型の利用</h2>
<p>次の例では、Product オブジェクトのコレクションから、価&#26684;が 200 円未満の Product オブジェクトを抽出する例です。</p>
<p><strong>例 5. Select 句での匿名型の利用</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>Public Class Form1</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private Sub Button1_Click(...) Handles Button1.Click &larr;Clickイベントハンドラ</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim products As New List(Of Product) From &larr;[1]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{New Product(100, &quot;Orange&quot;, 150D),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New Product(200, &quot;Peach&quot;, 200D),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New Product(300, &quot;Apple&quot;, 100D),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New Product(400, &quot;Banana&quot;, 120D),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New Product(500, &quot;PineApple&quot;, 300D)}</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim query2 = <strong>
From p In products Where p.Price &lt; 200D</strong> &larr;[2]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Select p.ProductID, p.ProductName</strong><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For Each p In query2 &larr;[3]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListBox1.Items.Add(p.ProductID &amp; &quot; &quot; &amp; p.ProductName) &larr;[4]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub</p>
<p>End Class</p>
<p>Public Class Product &larr;[5]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property ProductID As Integer<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property ProductName As String<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Property Price As Decimal<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public Sub New(ByVal id As Integer, ByVal nm As String, ByVal pr As Decimal)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProductID = id<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProductName = nm<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Price = pr<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
End Class</p>
</div>
<p>[2] の 2 行の太字部分がクエリ式です。In キーワードの後ろに記述されたクエリ対象となるデータソースproducts は List(Of Product) 型のコレクションであり、要素は Product オブジェクトです。よって、クエリ式 [2] の From キーワードの後に定義された要素を表す変数pは、1 つの Product オブジェクトを表す Product 型の変数となります。同様に、Where でも Product 型の変数となります。</p>
<p>仮に Select 句の記述を省略すれば、抽出されたものは加工されないので、1 つ 1 つの要素の姿は Product オブジェクトのままになり、単に抽出条件を満たす Product オブジェクトの集合になります。しかし、上記の Select 句では、抽出した要素である各 Product オブジェクトを加工し、2 つのプロパティ (p.ProductIDとp.ProductName) を並べているので、抽出後の各要素は文字通り、ProductID と ProductName の 2 つのプロパティからなるオブジェクトになります。</p>
<p>当然ながら、このような 2 つのプロパティのオブジェクトの型の定義 (クラス定義) はどこにも存在しないので、コンパイラが型の定義を自動生成します。このような型は「匿名型」といいます。</p>
<p>この匿名型の名前は明示的にソースコード上に書くことはできませんが、<a href="http://beta.code.msdn.microsoft.com/3-Variant-Dim-9801bb27">第 3 回</a>でも触れたように、型推論によって、[2] のクエリ変数 query2 の型は IEnumerable(Of 匿名型) になります。また他の部分でも、型の名前を明記できなくとも問題はなく、[3] の For Each ループにおいて抽出結果を参照する場合も、コンパイラによって p はこの匿名型と判断されます。さらに、[4]
 の &quot;p.ProductID&quot; のように、この匿名型のプロパティを参照できます。</p>
<p>なお、匿名型のプロパティ名を任意の名前に変更することもできます。次のように「名前 = 値」という形式で記述すると、元の ProductID プロパティと ProductName プロパティの値のままで、名前はそれぞれ ID プロパティ、Name プロパティになります。</p>
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Select</span>&nbsp;ID&nbsp;=&nbsp;p.ProductID,&nbsp;Name&nbsp;=&nbsp;p.ProductName&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>なお、Visual Basic 2008 からは、New キーワードおよび With キーワードを使用して明示的に匿名型を作成する構文が用意されています。それを利用すると、前述の 2 つの Select 句は次のように記述することもできます。</p>
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{p.ProductID,&nbsp;p.ProductName}&nbsp;
<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{&nbsp;.ID&nbsp;=&nbsp;p.ProductID,&nbsp;.Name&nbsp;=&nbsp;p.ProductName}&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>後者の場合は、ID プロパティと Name プロパティの前に、ドットを付ける必要があるので注意してください。</p>
<p style="margin-top:20px"><a href="#top"><img src="16901-image.png" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. 標準クエリ演算子の直接的な呼び出し</h2>
<p><a href="http://beta.code.msdn.microsoft.com/21-aac8643a">「第 21 回 ラムダ式の基本とその必要性」</a>で説明した Where メソッドを思い出してください。コンパイラは、プログラム上にクエリ式を見つけると、LINQ 関連のライブラリに定義された相応のメソッド呼び出しに変換します。例えば、Where 句であれば Where メソッドの呼び出し、Select 句であれば Select メソッドの呼び出しという具合です。このようなメソッドは、「標準クエリ演算子」と呼ばれています。上記のようなクエリ構文を使用せず、この標準クエリ演算子を直接呼び出すコードを書くことも可能です。</p>
<p>クエリ構文のほうが書き方としては簡単ですが、クエリ式の構文はライブラリに定義された標準クエリ演算子の呼び出しを網羅しているわけではないので、場合によっては、標準クエリ演算子を直接呼び出すコードを書くこともあります。実際、一部のサンプルコードでは、標準クエリ演算子を使用している例も見受けられます。また、ドキュメントに記載された標準クエリ演算子の定義が理解できるようになれば、より詳しく LINQ の動作が理解できるようになります。さらに、クエリ式が標準クエリ演算子の呼び出しにどう対応するかを知ることによって、クエリ式の最適化のヒントになることもあります。</p>
<p>ここで、基本的なクエリ演算子の使用例を見てみましょう。次の例 6 は例 5 の products コレクションに対するクエリ式と、それと同等の標準クエリ演算子の呼び出しを比較した例です。</p>
<p><strong>例 6. クエリ式と標準クエリ演算子</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim queryA = From p In products Where p.Price &lt; 200D Select p<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim queryB = products.Where(Function(p) p.Price &lt; 200D).Select(Function(p) p)</p>
</div>
<p>Visual Basic 2008 に慣れていないプログラマーの方は、後者のメソッド呼び出し形式のほうが、前者のクエリ式で行っていることが想像しやすいことでしょう。後者では、クエリ式に記述された Where 句、Select 句の順に、「メソッド」として呼び出しています。ここでは、Where メソッドを呼び出した結果の戻り値に対して、Select メソッドを呼び出すことになります。これらは、<a href="http://beta.code.msdn.microsoft.com/9-0a98f2cd">第
 9 回</a> にも説明した「拡張メソッド」として Visual Basic に追加 (拡張) されているメソッドです。</p>
<p>Where メソッドの引数には、上述の通り、クエリ式の Where 句の抽出条件が「ラムダ式」として渡ります。このラムダ式では、引数として渡された要素に関して、このラムダ式の抽出条件 &quot;p.Price &lt; 200D&quot; を評価することになります。(ラムダ式については、<a href="http://beta.code.msdn.microsoft.com/21-aac8643a">「第 21 回 ラムダ式の基本とその必要性」</a>を参照してください。)</p>
<p>この Where メソッドの定義は、<a href="http://beta.code.msdn.microsoft.com/18-Generic-58d5874b">第 18 回</a>や<a href="http://beta.code.msdn.microsoft.com/21-aac8643a">第 21 回</a>にも触れた以下のジェネリック メソッドです。今回は型パラメータ TSource の部分は Product なので、Where メソッドの戻り値 (下記の太字部分) は、IEnumerable(Of
 Product) 型です。</p>
<p><strong>例 7. (再掲) Where メソッドの定義</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>&lt;ExtensionAttribute&gt; _<br>
Public Shared Function Where(Of TSource) ( _<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source As IEnumerable(Of TSource), _<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;predicate As Func(Of TSource, Boolean) _<br>
) As <strong>IEnumerable(Of TSource)</strong></p>
</div>
<p>さらに、この Where メソッドの戻り値の集合に関して、例 6 では Select メソッドを呼び出して、各要素を加工しています。加工方法 (Select 句での記述内容) は、Select メソッドの引数として、ラムダ式を渡します。仮に、例 5 の [2] のクエリ式のように、プロパティを 2 つ列挙して匿名型のオブジェクトを作るなら、Select メソッドのラムダ式は次の太字部分のようになります。</p>
<p><strong>例 8. 匿名型のオブジェクトして返す</strong></p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim queryD = products.Where(Function(p) p.Price &lt; 200D) _<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Select(<strong>Function(p) New With {p.ProductID, p.ProductName}</strong>)</p>
</div>
<p>さてここで、例 6 の Select メソッドの呼び出しを見直してください。結局、この例 6 の Select メソッドでは要素に対して何も加工していないので、実は、Select メソッドの呼び出しを行う必要がありません。また、Select メソッドの呼び出しを記述しなければ、引数で渡された &quot;Function(p) p&quot; というラムダ式が、コンパイラによって無駄に匿名メソッドとして生成されることも無くなるということが読み取れるでしょう。</p>
<p>このように、クエリ式での各句 (Where 句や Select 句) とメソッド (標準クエリ演算子) の対応関係を把握しておけば、クエリ構文においても無駄を省くように調整できます。</p>
<p>以上、今回は基本的なクエリ式にまつわる留意点を取り上げました。これらを理解しておけば、プログラムの中で、実際に LINQ のクエリがどう作用するか理解も深まり、より使いこなせるようになることでしょう。</p>
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
