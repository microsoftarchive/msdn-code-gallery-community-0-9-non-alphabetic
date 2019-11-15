# 連載! とことん VB: 第 7 回 「参照渡し」という用語の誤解
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
<p>更新日: 2010 年 2 月 12 日</p>
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
<li><a href="#01">はじめに</a> </li><li><a href="#02">基本の確認～「値型」と「参照型」～</a> </li><li><a href="#03">改めて「参照渡し」とは? ～参照型の引数を渡すことではない～</a> </li><li><a href="#04">値型における「値渡し」と「参照渡し」</a> </li><li><a href="#05">参照渡しの基本的な用途</a> </li><li><a href="#06">「参照型引数の値渡し」の場合</a> </li><li><a href="#07">「参照型引数の参照渡し」が必要な理由</a> </li><li><a href="#08">結局のところ「参照渡し」は何を渡すのか?</a> </li></ol>
<hr>
<h2 id="01">1. はじめに</h2>
<p>今回は、メソッドへ引数を渡す方法に関して、特に注意すべき点を取り上げます。Visual Basic の学習を始めた方であれば、メソッドに引数を定義するとき、「値渡し」と「参照渡し」があることは既にご存じでしょう。このうち、「参照渡し」の意味を誤解されている方が見受けられます。そこで今回は、この「参照渡し」の意味を再確認し、どのような用途で使用するのか改めて解説します。</p>
<p style="margin-top:20px"><a href="#top"><img src="17032-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. 基本の確認～「値型」と「参照型」～</h2>
<p>ここで本題に入る前に、データ型の基本事項である「値型」と「参照型」の違いを確認しておきましょう。.NET 版の Visual Basic のデータ型は、.NET Framework に基づきます。そして、.NET Framework のデータ型には「値型」と「参照型」の 2 種類があり、データ型によってどちらの種類に分類されるかが決められています。次の例では、①に Integer 型の変数、③に MyData 型の変数が宣言されています。ここでは、MyData は任意に定義されたクラスと考えてください。.NET
 Framework では、Integer 型は「値型」であり、任意のクラスは「参照型」です。</p>
<p><strong>例 1. 値型と参照型</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Dim num As Integer		&larr;①

num = 10			&larr;②

Dim dt As MyData		&larr;③

dt = New MyData() With {.X = 100, .Y = 200}	&larr;④</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>①の値型の変数は、データそのものが&#26684;納される入れ物です。よって、②のように「10」を代入すれば、データ本体である「10」が変数という入れ物の中へ&#26684;納されます。</p>
<p>一方、③の参照型の変数は、入れ物には違いないのですが、データそのものが&#26684;納されるわけではなく、メモリ上に配置されたデータが「どこにあるのか」という情報が&#26684;納されます。例えば、メモリ上の 1000 番地にデータ本体があれば、そのデータを表すための参照型変数には「1000」という値 (アドレス) が&#26684;納されます。</p>
<p>よって、参照型の変数への代入文における典型的な使用方法は、④のように New キーワードを使用して、改めてメモリ上にデータを確保して (ここでは MyData オブジェクト インスタンスを確保して)、代入文の右辺に記述することで、左辺の変数 dt がこのオブジェクトを表すようにします。</p>
<p>変数 dt に代入されたのは、オブジェクト本体ではなく、あくまで「オブジェクトがメモリ上のどこにあるか」という情報 (アドレス) が&#26684;納されます。このような情報のことを「参照」とも呼びます。つまり、参照型の変数の入れ物には、「参照」が&#26684;納されます。</p>
<div style="margin:10px auto; padding:10px 10px 0px 10px; background-color:#efefef; border:solid 1px #333333; width:550px">
<p><strong>Note:</strong> ④の「With { .X =100, .Y = 200)」という句は Visual Basic 2008 から登場した新しい構文で、インスタンスを作成すると同時に、そのインスタンスの各プロパティに値を設定するものです。ここでは、このオブジェクトに X プロパティと Y プロパティがあると考えてください。</p>
</div>
<p style="margin-top:20px"><a href="#top"><img src="17033-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. 改めて「参照渡し」とは? ～参照型の引数を渡すことではない～</h2>
<p>ここで本題に入ります。前述の参照型もメソッドの引数として渡すことができます。当然ながら、引数も変数の一種なので、参照型の引数という入れ物には「参照」が&#26684;納されています。呼び出し元から呼び出し先へ「参照」が渡ります。</p>
<p>しかしながら、このような「参照型の引数」を渡すこと自体は「参照渡し」ではありません。一部のテクノロジでは、このことを「参照渡し」と呼んでいる場合も見受けられます。しかし、.NET が登場する以前から Visual Basic の世界では、これを「参照渡し」と呼んではいませんでした。もちろん、現在の .NET Framework でも、「参照型の引数」を渡すことを「参照渡し」とは呼びません。</p>
<p>メソッドの引数を定義する際に、修飾子 ByVal または修飾子 ByRef を付けることによって、「値渡し」または「参照渡し」のどちらかに決まります。そして、このことは別に、上述したように As 句を使用して、引数の型を「値型」 (例えば、Integer など) または「参照型」に定義できます。つまり、組み合わせは合計で以下の 4 通り ([A] から [D]) が考えられます。</p>
<p><strong>表 1. 引数の渡し方とデータの種類の 4 つの組み合わせ</strong></p>
<table class="grid" border="1" cellspacing="0" cellpadding="5" width="600px;" style="border-collapse:collapse; margin:15px auto">
<tbody>
<tr align="center" valign="middle" style="background-color:#eff3f7">
<td valign="top">&nbsp;</td>
<td valign="top">値型の引数</td>
<td valign="top">参照型の引数</td>
</tr>
<tr>
<td valign="top">修飾子 ByVal</td>
<td valign="top">[A] 値型の引数で、かつ値渡し<br>
ByVal number As Integer</td>
<td valign="top">[C] 参照型の引数で、かつ値渡し<br>
ByVal data As MyData</td>
</tr>
<tr>
<td valign="top">修飾子 ByRef</td>
<td valign="top">[B] 値型の引数で、かつ参照渡し<br>
ByRef number As Integer</td>
<td valign="top">[D] 参照型の引数で、かつ参照渡し<br>
ByRef data As MyData</td>
</tr>
</tbody>
</table>
<p>この表からも分かるように、引数が「値型」の場合でも、[A] の「値渡し」もあれば、[B] の「参照渡し」もあります。結局のところ、引数のデータ型とは無関係に「値渡し」と「参照渡し」という 2 つの渡し方があります。</p>
<p>では、それぞれの渡し方の違いを確認しましょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="17034-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. 値型における「値渡し」と「参照渡し」</h2>
<p>分かりやすくするため、まずは値型の引数である [A] と [B] について考えてみます。次の例は、上記の [A] と [B] の引数を渡す例です。(実行確認をしたい方は、適当な Windows アプリケーションを作成し、フォームにボタンを貼り付け、ボタンの Click イベント ハンドラを生成させた後、このコードと同じになるように編集してみてください。)</p>
<p><strong>例 2. 「値渡し」と「参照渡し」</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Private Sub Button1_Click(ByVal sender ...	&larr;Clickイベントハンドラ

Dim num1 As Integer = 10	&larr;①

    Dim num2 As Integer = 20	&larr;②

    CountUp(num1, num2)		&larr;③

    MsgBox(String.Format(&quot;num1={0} num2={1}&quot;, num1, num2))			&larr;④

End Sub



Private Sub CountUp(ByVal number1 As Integer, ByRef number2 As Integer)	&larr;⑤

    number1 &#43;= 1	&larr;⑥

    number2 &#43;= 1	&larr;⑦

End Sub</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>ここでは、⑤の CountUp メソッドの引数定義の際に、[A] と [B] に相当する引数として、「値渡し」の引数 number1 と「参照渡し」の number2 があります。この 2 つの引数は、呼び出し元から渡される引数の受け皿となります。このような受け取り側の引数は「仮引数」といいます。このメソッドの内部では⑥と⑦にあるように、2 つの仮引数について、それぞれ 1 だけ値を加算しています。</p>
<p>一方、①と②では値型の変数 num1 と num2 が宣言されており、それぞれの値は「10」と「20」です。そして、③で CountUp メソッドを呼び出す際に、この 2 つの変数を引数として渡しています。このような呼び出し元の引数は「実引数」と言います。</p>
<p>結局のところ、実引数の num1 と num2 の値である「10」と「20」は、それぞれ仮引数の number1 と number2 へ渡ります。ただし、その渡り方が異なります。仮引数 number1 は「値渡し」として定義されています。この場合、実引数 num1 と仮引数 number1 は、それぞれメモリ上の別々の領域を意味しており、引数が渡る際には、実引数 num1 の値「10」は、仮引数 number1 へコピーされます。これに対して、仮引数 number2 は「参照渡し」として定義されています。この場合は、実引数
 num2 と仮引数 number1 は、メモリ上の同じ領域を意味します。いわば、仮引数 number2 は実引数 num2 に名付けられた「別名」 (エイリアス) と解釈できます。</p>
<p>この渡し方の違いのため、⑥と⑦に記述された仮引数への加算操作は、異なる効果をもたらします。「値渡し」の場合、あくまで仮引数はコピーなので、⑥のところで仮引数 number1 へ加算しても、元になった実引数 num1 は変更されません。「コピーされた用紙」に落書きしても、「原紙」は元のままであるのと同じです。しかし「参照渡し」では、実引数と仮引数は同一なので、⑦のように仮引数 number2 に加算することは、実引数 num2 に加算することと同じです。参照渡しの仮引数は実引数と同じ「原紙」なので、仮引数に加算することは「原紙」そのものに落書きすることです。よって、このプログラムの
 Click イベント ハンドラを実行すると、④のメッセージ ボックスには、「num1=10 num2=21」と表示され、実引数の一方である変数 num2 だけが加算されます。</p>
<p>このことから、「値渡し」と「参照渡し」の違いは、元になる実引数を変更できるかどうかの違いということになります。これをふまえ、まず基本的な「参照渡し」の用途をまとめてみましょう。</p>
<div style="margin:10px auto; padding:10px 10px 0px 10px; background-color:#efefef; border:solid 1px #333333; width:550px">
<p><strong>Note:</strong> 「参照渡し」において、仮引数と実引数が同じメモリ領域を表すといっても、これが物理的に不可能な場合もあります。例えば、Web サービス呼び出しなどを利用して、呼び出し元と呼び出し先が別のマシンの場合です。この場合は、あたかも仮引数と実引数が同一であるかのように見せるため、呼び出しの際には、仮引数と実引数の値の同期が自動的に行われます。</p>
</div>
<p style="margin-top:20px"><a href="#top"><img src="17035-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. 参照渡しの基本的な用途</h2>
<p>「参照渡し」の基本的な用途は、前述の③の実引数 num2 の値が変わることから分かるように、呼び出し元の変数の値を変更することです。しかし、呼び出し元の変数の値を変えたいなら、次のように戻り値を利用する代替方法もあります。</p>
<p><strong>例 3. 戻り値として加算結果を受け取る (抜粋)</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Dim num2 As Integer = 20

num2 = CountUp(num2)		&larr;①

			

    :



Private Function CountUp(ByVal number) As Integer	&larr;②

Return  (number &#43; 1)

End Function</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>上記の②の CountUp メソッド (Function プロシージャ) では、「値渡し」として仮引数でデータを受け取り、メソッドの中で仮引数に 1 を加算した「計算結果」を戻り値として返します。仮引数自体に加算はしませんが、加算した計算結果を呼び出し元に返すことができます。そして①では、実引数として num2 を渡した上で、戻り値を改めて num2 に代入して、変数 num2 の値を変更しています。これでも例 2 と同じように、呼び出し元の変数へ 1 だけ加算できます。</p>
<p>しかし言語仕様上、戻り値は 1 つしか書けません。メソッド呼び出しの際に、呼び出し元の 2 つ以上のデータを同時に変更する必要があるなら、1 つの方法として「参照渡し」を使うことができます。<br>
また、独自のライブラリを作成する場合、メソッドの戻り値には処理結果を表すステータス コードを返すよう、すべてのメソッドを統一する場合もあります。この場合、呼び出し元の変数を変更する手段として戻り値を利用できません。こうした状況の場合は、呼び出し元の値を変更するために、やはり「参照渡し」を使用する場合があります。</p>
<p style="margin-top:20px"><a href="#top"><img src="17036-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="06">6. 「参照型引数の値渡し」の場合</h2>
<p>なお、ここで 1 つ疑問が起こるかも知れません。『「参照型」の引数なら「値渡し」でも、呼び出し元のデータが加工できるのではないか?』と。例えば、次のような例です。</p>
<p><strong>例 4. 「参照型」の引数なら「値渡し」でも、呼び出し元を変更できるが...</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Public Class MyData				&larr;①

     Public Property X As Integer 'Auto-Implemented Properties	&larr;②

     Public Property Y As String

End Class



Private Sub Button1_Click(ByVal sender ...	&larr;Clickイベントハンドラ

Dim dt As MyData

dt = New MyData() With {.X = 100, .Y = 200}		&larr;③

CountUpData(dt)						&larr;④

MsgBox(String.Format(&quot;dt.X={0} dt.Y={1}&quot;, dt.X, dt.Y))	&larr;⑤

End Sub



Private Sub CountUpData(ByVal data As MyData)			&larr;⑥

     data.X &#43;= 1

     data.Y &#43;= 1

End Sub</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>上記の例では、①に MyData のクラス定義があります。さらに②から始まる 2 行では、このクラスの X プロパティと Y プロパティを定義しています。</p>
<div style="margin:10px auto; padding:10px 10px 0px 10px; background-color:#efefef; border:solid 1px #333333; width:550px">
<p><strong>Note:</strong> ここには、プロパティの Get プロシージャと Set プロシージャがありません。これは、Visual Basic 10.0 (Visual Studio 2010 における Visual Basic) から導入された「Auto-Implemented Property」という、プロパティ定義の新しい簡易表現です。具体的なプロパティの実装を後から決める予定があり、暫定的にプロパティを定義したい場合などに便利です。詳しくは、別の回で取り上げます。</p>
</div>
<p>③では、MyData クラスのオブジェクト インスタンスを作成し、その際に 2 つのプロパティには、それぞれ「100」と「200」を代入しています。もちろん、③の変数 dt はクラスのインスタンスを表すので「参照型」です。そして、④では変数 dt を実引数として CountUp メソッドを呼び出します。</p>
<p>一方、⑥では「値渡し」として仮引数 data が定義されています。「値渡し」なので、仮引数は実引数のコピーですが、ここで実引数から仮引数にコピーされるのは、インスタスン自体ではなく、インスタンスがメモリ上のどこにあるかという情報、すなわち「参照」です。元のインスタンスの「参照」が仮引数 data に渡るので、実引数と仮引数は、同じオブジェクト インスタンスを表します。</p>
<p>よって、⑥のメソッドの中で行われる X プロパティと Y プロパティへの加算は、元のオブジェクト インスタンスへの加算になります。その結果、⑤では「dt.X=101 dt.Y=201」と表示され、たしかに元のオブジェクト インスタンスのデータが変更されます。</p>
<p>この例のパターンは、表 1 の [C] である「参照型」の引数の「値渡し」です。この渡し方で、呼び出し元のオブジェクト インスタンスのデータが変更できるのなら、わざわざ [D] の「参照型」の引数の「参照渡し」は不要にも思えてしまいます。</p>
<p>いえいえ、そうではありません。[C] と [D] では、変更できる内容が違います。[C] の場合では、実引数 dt が表わすオブジェクト インスタンスは、呼び出した後も同じであって、オブジェクト インスタンスの中のデータだけが変更される点に注意してください。</p>
<p style="margin-top:20px"><a href="#top"><img src="17037-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="07">7. 「参照型引数の参照渡し」が必要な理由</h2>
<p>[D] の「参照型」の引数の「参照渡し」が必要なシナリオは、どんな場合でしょうか。先に触れた「参照渡し」の特徴を正確に思い出してください。前述の通り、「参照渡し」では、呼び出し元の実引数自体が変更されます。例 4 の③の変数 dt に当てはめると、変数 dt に&#26684;納された「参照」そのものを変更したい場合です。つまり、変数 dt が表わす (参照する) インスタンスを異なるインスタンスへ変更したい場合には、「参照型」の引数の「参照渡し」が使用できます。例えば、次のような場合に使用します。</p>
<p><strong>例 5. メソッド呼び出しによって、実引数に参照を設定する</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><code class="csharp">Private Sub Button1_Click(ByVal sender ...	&larr;Clickイベントハンドラ

Dim dt As MyData

    If CreateData(dt) Then	&larr;①

        MsgBox(String.Format(&quot;dt.X={0} dt.Y={1}&quot;, dt.X, dt.Y))

    End IfEnd Sub

End Sub



Private Function CreateData(ByRef data As MyData) As Boolean	&larr;②

    Try

        data = New MyData() With {.X = 300, .Y = 500}		&larr;③

        Return True						&larr;④

    Catch ex As Exception	&larr;⑤

        data = Nothing

        Return False

    End Try

End Function</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>上記の②の CreateData メソッドは、MyData クラスのインスタンスを特定の初期値で作成します。ここでは、表 1 の [D] のパターンを使用しています。(仮引数 data は「参照型」であり「参照渡し」です。) また、このメソッドの中の③では、MyData クラスの新しいインスタンスを作成し、その「参照」を仮引数 data に代入しています。③でエラーが発生せず、無事にインスタンスが作成できれば、④のように戻り値は True です。逆に、万が一インスタンスの作成に失敗した場合、⑤の Catch
 ブロックに実行制御が遷移し、戻り値は False になります。</p>
<p>一方、呼び出し元の①では、呼び出しの戻り値を If 文でチェックしています。もし、戻り値が True ならば、実引数として渡された dt には、新しいインスタンスの参照が代入されているはずです。ここでは、実際に True になり、実引数の dt にも新しいインスタンスの参照が代入されます。これが可能なのは、「参照渡し」だからです。「参照渡し」の場合では、③で仮引数 data に新しいインスタンスの参照を代入することは、①の実引数 dt に参照を代入することになります。</p>
<p>仮にこの例が「値渡し」ならどうなるでしょう。「値渡し」ならば仮引数と実引数は別々の変数なので、③で仮引数 data に参照を代入しても、①の実引数には代入できません。<br>
このように、引数が参照型であっても、実引数である「参照」自体に変更を加える場合は、「参照渡し」が必要なのです。</p>
<p style="margin-top:20px"><a href="#top"><img src="17038-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="08">8. 結局のところ「参照渡し」は何を渡すのか?</h2>
<p>ここまでの時点で「参照渡し」とは何か、まとめると次のようになります。</p>
<ol style="list-style-type:square">
<li>修飾子 ByRef を付けて定義した仮引数 (仮引数の型が「値型」や「参照型」であることと無関係) </li><li>仮引数は、実引数の別名 (エイリアス) である </li><li>呼び出し元の実引数を呼び出し先のメソッドから変更するときに使用する </li></ol>
<p>特に用途としてのポイントは、上記の 3 つのうちの 3 番目が重要です。</p>
<p>ここまでの話で、まだしっくり来ない方も居られるかもしれません。上記の 3 つの項目には、「何を渡すのか」という意味が現われていません。いったい「参照渡し」で渡されるものは何なのでしょうか?</p>
<p>実は、MSDN ライブラリに記載された ByRef キーワードの説明 (定義) を見ると、「仮引数を変更することによって、呼び出し元の変数を変更できるようになる」という旨の説明はあるのですが、「何を渡すのか」は明確に示されていません。本来の目的である「呼び出し元の実引数を変更する」という目的のみが記載されています。しかし、.NET 版の Visual Basic や .NET Framework の元になる「共通言語基盤 (CLI: Common Language Infrastructure)」という仕様から、その答えは導き出せます。これによると、例えば「参照型」の引数を「参照渡し」で渡す場合は、実引数という入れ物に&#26684;納された「参照」が渡るのではなく、実引数自身がメモリ上のどこにあるのかという、実引数自身の場所を特定するための「参照」が渡るのです。それであれば、実引数と仮引数が同じメモリ領域を表せるという「参照渡し」の特徴もうなずけます。</p>
<p>次のように考えてみましょう。</p>
<p>「参照渡し」の仮引数を持つメソッドと、実引数を持つ呼び出し元は、同時にコンパイルされるとはかぎりません。つまり、コンパイル時に同一のメモリ領域を仮引数と実引数に割り当てることができません。そうなると、呼び出し元から呼び出されるメソッドへ、実行時に何らかの情報を渡さないと、実引数と仮引数は同じメモリ領域を表すことができません。このとき、「実引数自体がどこにあるか」という「参照」をメソッドに渡せば、呼ばれる側のメソッドは実引数の場所を特定できます。</p>
<p>よって「参照渡し」では、たしかに「参照」が渡っていますが、ソースコード上の実引数という入れ物に&#26684;納された「参照」が渡ると考えたら間違いなのです。渡るのはあくまで、「実引数という入れ物自体がどこにあるのかを示す『参照』」であり、実引数という入れ物が「値型」であろうと「参照型」であろうと関係ありません。(いずれにしても、「参照渡し」で「何が渡るか」という点は、「参照渡し」を使う上であまり意識する必要はなく、やはり大切なのは具体的な作用や用途です。)<br>
本実際の開発の現場では、プログラム間の引数などのデータのやり取りは頻繁に必要となるはずです。その際、開発メンバーの間で正しくコミュニケーションを取るためにも、本当に全員が「参照渡し」の作用や用途について共通の認識を持っているか、確認する必要があるかも知れません。</p>
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
