   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	   #    Project2016App.CalcuateSalary   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	     � Title$F  @คำนวณเงินเดือนพนักงาน ��5   	    � 
ResizeMode$ NoResize=�6(    � Icon$ iconapp.ico��6>    � WindowStartupLocation$ CenterScreen=�6R   $��713.5��6�   $	��950��6�   .��5	      � ��5
   
   �� 5       �� ImageSource$ image/bg-salary.jpg��6    �� Opacity$	 0.1Q�6;   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��	423,9,0,0q�6B   $
��Wrap=�6U   $T��Nตารางแก้การบันทึกเข้าทำงาน��6i   $	��Top=�6�   $
��Bold"�6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��54��6T   $��	22,64,0,0q�6`   $	��Top=�6s   $	��395��6�   �� 5   
   
�������$
��Left=�6!   $��22��6<   $��	32,55,0,0q�6H   
�������$	��Top=�6j   $��68��6�   �� 5   
   -   5         ��Name$ label��5      $'��!ค้นหาวันที่��6   $
��Left=�65   $��	37,50,0,0q�6P   $	��Top=�6c   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	datePick1��5      $
��Left=�6(   $��	65,85,0,0q�6C   $	��Top=�6V   $��94��6n     5   
   -   5        $ 	datePick2��5      $
��Left=�6(   $��
214,85,0,0q�6C   $	��Top=�6W   $��96��6o   �� 5   
   -   5        $ label1��5      $��	จาก��6    $
��Left=�6.   $��	31,83,0,0q�6I   $	��Top=�6\   �� 5   
   -   5        $ label2��5      $��	ถึง��6    $
��Left=�6.   $��
179,83,0,0q�6I   $	��Top=�6]   �� 5   
   -   5        	 ��Name$	 Search��5      $��ค้นหา��6!   $
��Left=�61   $��
341,86,0,0q�6L   $	��Top=�6`   $��58��6x   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dataGrid��5      $
��Left=�6%   $��
22,130,0,0q�6@   $	��Top=�6T   $	��466��6l   $	��898��6y      AutoGenerateColumns .  
�������   CanUserResizeRows .     CanUserResizeColumns .     CanUserReorderColumns .   �� SelectedIndex$ 0��6	     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    CanUserResize .     Header$ วันที่��6�      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6�      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	checkDate+ �� StringFormat$ {0:dd/MM/yyyy}��   ClipboardContentBinding 6�   Z� 6�     5       .    CanUserReorder .   .  $' !รหัสพนักงาน��6�   $	 200 6�    .  6%   �� *	checkID+ 6�   Z� 6�     5       .  .  $' !ชื่อพนักงาน��6�   $	 200 6�    .  6%   �� *	checkName+ 6l   Z� 6�     5       .  .  $0 *นามสกุลพนักงาน��6�   $	 200 6�    .  6%   �� *checkLastname+ 6p   Z� 6�     5       .  .  $ สถานะ��6�   $	 200 6�    .  6%   �� *checkStatus+ 6n   Z� 6�     5       .  .  $0 *รายได้ประจำวัน��6�   $	 200 6�    .  6%   �� *
checkPay+ 6k   Z� 6�     5       .  .  $ หมายเหตุ��6�   $	 200 6�    .  6%   �� *	checkInfo+ 6l   Z� 6�   5       �� 5!   
   -	   5        $ label3��5!      $*��$ค้นหาพนักงาน��6    $
��Left=�67   $��
496,56,0,0q�6R   $	��Top=�6f   $	��100��6~   �� 5"   
   -
   5         ��Name$ 	Searchbox��5"      $
��Left=�6%   $��30��6@   $��
500,88,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��177��6�   6�   �� 5#   
   $
��Left=�6   $��49��6/   $��450,603,0,0q�6;   $	��Top=�6P   $��48��6h   ��5$      �� 5%      $ image/save.ico��6   5'      �� 5(   
   -   5        $	 InsertSalary��5(      $3��-บันทึกเงินเดือน��6'   $
��Left=�6A   $��454,603,0,0q�6\   $	��Top=�6q   $��41��6�   $��48��6�    J� Opacity$ 0Q�6�   �� 5)   
   -   5        $ label4��5)      $��บันทึก��6    $
��Left=�61   $��454,647,0,-2q�6L   $	��Top=�6b   $
��Bold"�6z   �� 5*   
   
���   �$��1q�6%   $
��Left=�69   $��76��6T   $��
684,42,0,0q�6`   $	��Top=�6t   $	��233��6�   �� 5+   
   
�������$
��Left=�6!   $��22��6<   $��
693,30,0,0q�6H   
�������$	��Top=�6k   $��84��6�   �� 5,   
   -   5        $ 
label_Copy��5,      $0��*ค้นหาเพิ่มเติม��6$   $
��Left=�6=   $��
698,25,0,0q�6X   $	��Top=�6l   	� 5-   
   -   5         	�Name$
 rdb1��5-      $��มาปกติ��6$   $
��Left=�65   $��
691,58,0,0q�6P   $	��Top=�6d   6|   	� 5.   
   -   5        $
 rdb2��5.      $$��มาครึ่งวัน��6$   $
��Left=�69   $��
691,79,0,0q�6T   $	��Top=�6h   6�   	� 5/   
   -   5        $
 rdb3��5/      $��	ขาด��6$   $
��Left=�62   $��691,100,0,0q�6M   $	��Top=�6b   6z     50   
   $
��Left=�6   $��
338,34,0,0q�60   $	��Top=�6D   51      52      