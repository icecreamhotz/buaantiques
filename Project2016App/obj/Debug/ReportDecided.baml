   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   I EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App 5   	   "   Project2016App.ReportDecided   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   .localclr-namespace:Project2016App     5   	   -   5          � Title$<  6รายงานการส่งสินค้า��5	   	    � 
ResizeMode$ NoResize=�6$    � Icon$ iconapp.ico��6:    � WindowStartupLocation$ CenterScreen=�6N   $	��700��6s   $	��978��6�   .��5
      � ��5   
   �� 5       �� ImageSource$ image/report-bg.png��6    �� Opacity$	 0.2Q�6;   .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $��60��6T   $��	54,59,0,0q�6`   $	��Top=�6s   $	��505��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��104��6T   $��	37,21,0,0q�6a   $	��Top=�6t   $	��896��6�   �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
479,24,0,0q�6B   $
��Wrap=�6V   $<��6รายงานการส่งสินค้า��6j   $	��Top=�6�   �� 5   
   -   5         ��Name$ label��5      $'��!ค้นหาวันที่��6   $
��Left=�65   $��	54,36,0,0q�6P   $	��Top=�6c   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	datePick1��5      $
��Left=�6(   $��
111,82,0,0q�6C   $	��Top=�6W   $	��146��6o   �� 5   
   -   5        $ label1��5      $��วันที่��6    $
��Left=�61   $��	66,81,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        	 ��Name$	 Search��5      $��ค้นหา��6!   $
��Left=�61   $��
480,84,0,0q�6L   $	��Top=�6`   $��58��6x   6�   �� 5   
   -   5        $	 bt_Edit��5      $'��!ปิดหน้าต่าง��6"   $
��Left=�68   $��843,616,0,0q�6S   $	��Top=�6h   $��92��6�   $��42��6�   
���  ��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dataGrid��5      $
��Left=�6%   $��
38,132,0,0q�6@   $	��Top=�6T   $	��468��6l   $	��896��6y      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! วันที่ส่ง��6�      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�      CanUserResize .     
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *stockhisDate+ �� StringFormat$ {0:dd/MM/yyyy}��   ClipboardContentBinding 6d   Z� 6�     5      $$ รหัสสินค้า��6d   $	 100 6x    .   .  6%   �� *	proCode+ 6A   Z� 6�     5      $$ ชื่อสินค้า��6d   $	 100 6x    .   .  6%   �� *	proName+ 6A   Z� 6�     5      $< 6จำนวนสินค้าก่อนส่ง��6j   $	 100 6�    .   .  6%   �� *stockTotalold+ 6G   Z� 6�     5      $9 3ตำนวนสินค้าที่ส่ง��6j   $	 100 6�    .   .  6%   �� *stockTotalnew+ 6G   Z� 6�     5       .  $ คงเหลือ��6�   $	 100 6�    .  6%   �� *stockTotallast+ 6^   Z� 6�     5       .  $ ราคาขาย��6�   $	 100 6�    .  6%   �� *stocksellPrice+ 6^   Z� 6�     5       .  $3 -จำนวนเงินที่ได้��6�   $	 100 6�    .  6%   �� *stockTotalprice+ 6_   Z� 6�     5        .  $* $ประเภทสินค้า��6   $	 100 6�    .  6%   �� *typenameUnit+ 6\   Z� 6�     5!       .  $0 *หน่วยนับสินค้า��6|   $	 100 6�    .  6%   �� *	typepName+ 6Y   Z� 6�     5"       .  $ หมายเหตุ��6   $	 100 6�    .  6%   �� *stockhisInfo+ 6\   Z� 6�     5#       .  $< 6จำนวนเงินที่ได้รับ��6�   $	 100 6�    .  6%   �� *stockhisMoney+ 6]   Z� 6�   5%        5&   
   -	   5        $ 	datePick2��5&      $
��Left=�6(   $��
314,82,0,0q�6C   $	��Top=�6W   $	��146��6o   �� 5'   
   -
   5        $ label1_Copy��5'      $!��ถึงวันที่��6%   $
��Left=�69   $��
266,81,0,0q�6T   $	��Top=�6h   �� 5(   
   -   5        $	 bt_Print��5(      $��พิมพ์��6#   $
��Left=�63   $��
38,616,0,0q�6N   $	��Top=�6b   $��92��6z   $��42��6�   ���	#FF51FF006�   5+      5,      