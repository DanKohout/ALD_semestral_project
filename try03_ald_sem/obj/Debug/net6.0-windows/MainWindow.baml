   M S B A M L   `   `   `  ????H  Dtry03_ald_sem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:try03_ald_semtry03_ald_sem  5   	       try03_ald_sem.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:try03_ald_sem     5   	     ? Title$  	Generator??5   	   $	??523??6   $	??596??6(      BackgroundColor#??[  5	   	     	TextColor#??[ 5
   	    ? WindowStartupLocation$ CenterScreen=?5   	   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ?? -   5         ??Name$ 	ScoreText??5      $??Center=?5      $??Center=?5      $
??grid??5      $??1??6    ?? 5   
   -   5         ??Name$ Resetbtn??5      $??0??5      $??1??6!   $??50??5      $??30??6     GridLineColor#??[ 5      .??5      ?? .?6   Reset6   5       ?? 5!   
   -   5        $ Stepbtn??5!      $??0??5"      $??1??6!   $??50??5#      $??30??6   $??0,70,0,0q?6(   #??[ 5$      .??5&      ?? .?6   Step6   5'      ?? 5(   
   -   5        $ 	Finishbtn??5(      $??0??5)      $??1??6!   $??50??5*      $??30??6   $??	0,140,0,0q?6(   #??[ 5+      .??5-      ?? .?6   Finish6   5.      ?? 5/   
   -   5         ??Name$ 
GridBorder??5/      $??1??50      #??[ 51      $	??1.5q?52      $??Center=?53      $??Center=?54      $??1??6,   ._?55      A? -   5         A?Name$ GameGrid??55      $	??400??56      $	??400??57        GridBackgroundColor#??[ 58      5:      5<      ?? 5>   
   -   5         ??Name$ 
GameScreen??5>      $
|?True??6%   $??2??6`   $??	0,0,0,511q?6t   $??2??6?   .+?5?      ?? -   5        	 ??Name$	 Player??5?   P   
 ?? Left$
 8??6   ???	#AFFF0000$??50??69   $??50??6D   $
??Left=?6`   $??Center=?6{   
 ?? Top$ 56??6?   5@      5A      5B      