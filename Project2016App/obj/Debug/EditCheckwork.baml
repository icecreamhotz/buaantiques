   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	   "    Project2016App.EditCheckwork   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	     � Title$K  Eแก้ไขบันทึกการเข้าทำงาน��5   	    � 
ResizeMode$ NoResize=�6)    � Icon$ iconapp.ico��6?    � WindowStartupLocation$ CenterScreen=�6S   $	��700��6�   $	��950��6�   .��5	      � ��5
   
   �� 5       �� ImageSource$ image/bg-checkwork.jpg��6    �� Opacity$	 0.2Q�6>   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
390,24,0,0q�6B   $
��Wrap=�6V   $T��Nตารางแก้การบันทึกเข้าทำงาน��6j   $	��Top=�6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��54��6T   $��
146,64,0,0q�6`   $	��Top=�6t   $	��264��6�   �� 5   
   
�������$
��Left=�6!   $��22��6<   $��
156,55,0,0q�6H   
�������$	��Top=�6k   $��68��6�   �� 5   
   -   5         ��Name$ label��5      $'��!ค้นหาวันที่��6   $
��Left=�65   $��
161,50,0,0q�6P   $	��Top=�6d   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	datePick1��5      $
��Left=�6(   $��
189,85,0,0q�6C   $	��Top=�6W   $��94��6o   �� 5   
   -   5        $ label1��5      $��วันที่��6    $
��Left=�61   $��
155,83,0,0q�6L   $	��Top=�6`   �� 5   
   -   5        	 ��Name$	 Search��5      $��ค้นหา��6!   $
��Left=�61   $��
310,87,0,0q�6L   $	��Top=�6`   $��58��6x   6�   �� 5   
   -   5        $	 bt_Edit��5      $��แก้ไข��6"   $
��Left=�62   $��417,622,0,0q�6M   $	��Top=�6b   $��78��6z   $��28��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dataGrid��5      $
��Left=�6%   $��
20,132,0,0q�6@   $	��Top=�6T   $	��468��6l   $	��898��6y      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ วันที่��6�      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�      CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	checkDate+ �� StringFormat$ {0:dd/MM/yyyy}��   ClipboardContentBinding 6a   Z� 6�     5      $' !รหัสพนักงาน��6d   $	 100 6y    .   6%   �� *	checkID+ 6A   Z� 6�     5      $ ชื่อ��6f   $	 100 6t    .   6%   �� *	checkName+ 6C   Z� 6�     5      $ นามสกุล��6j   $	 100 6{    .   6%   �� *checkLastname+ 6G   Z� 6�     5      $ สถานะ��6h   $	 100 6w    .   6%   �� *checkStatus+ 6E   Z� 6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5       .  $! มาเต็มวัน��6{   $	 100 6�    6)   �� *cbk1+ 6X   Z� 6�     5       .  $0 *มาครึ่งวันหน้า��6{   $	 100 6�    6)   �� *cbk2+ 6X   Z� 6�     5       .  $0 *มาครึ่งวันหลัง��6{   $	 100 6�    6)   �� *cbk3+ 6X   Z� 6�     5       .  $ 	ขาด��6{   $	 100 6�    6)   �� *cbk4+ 6X   Z� 6�     5        .  $ หมายเหตุ��6|   $	 100 6�    6%   �� *	checkInfo+ 6Y   Z� 6�     5!       .  $' !จำนวนบันทึก��6~   $ 0 6�      MaxWidth$ 0Q�6�      MinWidth$ 0Q�6�    6%   �� *checkworkID+ 6[   Z� 6�   5#      �� 5$   
   -   5         ��Name$ 
Searchname��5$      $
��Left=�6&   $��24��6A   $��
588,92,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $��94��6�   6�   �� 5%   
   -	   5        $ label3��5%      $*��$ค้นหาพนักงาน��6    $
��Left=�67   $��
588,59,0,0q�6R   $	��Top=�6f   $	��100��6~   5(      5)      