   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	   $    Project2016App.ManageCheckwork   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	     � Title$E  ?ตรวจสอบการบันทึกทำงาน��5   	    � 
ResizeMode$ NoResize=�6'    � Icon$ iconapp.ico��6=    � WindowStartupLocation$ CenterScreen=�6P   $	��500��6�   $	��850��6�   .��5	      � ��5
   
   �� 5       �� ImageSource$ image/bgemployee.jpg��6    �� Opacity$	 0.2Q�6<   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
327,22,0,0q�6B   $
��Wrap=�6V   $`��Zตารางตรวจสอบการบันทึกเข้าทำงาน��6j   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%    %� IsVirtualizing .  $��153,125,0,0q�6n   $	��Top=�6�   $	��272��6�   $	��568��6�   	   CanUserResizeColumns	 .  
   CanUserSortColumns
 .     CanUserReorderColumns .     AutoGenerateColumns .     Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      -   5        	ckbColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 5   `      Header$ ลบข้อมูล��6k   1  +System.Windows.Controls.DataGridBoundColumn   ClipboardContentBinding 6=   Z� 6k   0  *System.Windows.Controls.DataGridTextColumn  5      $ วันที่��6�   $	 100 6�      CanUserSort .     CanUserResize .     
IsReadOnly .    Binding 6%   �� *	checkDate+ �� StringFormat$ {0:dd/MM/yyyy}�� 6a   Z� 6�     5      $ รหัส��6d   $	 100 6r    .   .   .  6%   �� *	checkID+ 6A   Z� 6�     5      $ ชื่อ��6f   $	 100 6t    .   .   .  6%   �� *	checkName+ 6C   Z� 6�     5      $ นามสกุล��6j   $	 100 6{    .   .   .  6%   �� *checkLastname+ 6G   Z� 6�     5      $ สถานะ��6h   $	 100 6x    .   .   .  6%   �� *checkStatus+ 6E   Z� 6�     5      $0 *รายได้ประจำวัน��6e   $	 100 6}    .   .   .  6%   �� *
checkPay+ 6B   Z� 6�     5      $ หมายเหตุ��6f   $	 100 6x    .   .   .  6%   �� *	checkInfo+ 6C   Z� 6�     5      $* $วันที่บันทึก��6e   $	 200 6{    .   6%   �� *
saveInfo+ 6B   Z� 6�     5      $* $วันที่บันทึก��6h   $ 0 6~    .   6%   �� *checkworkID+ 6E   Z� 6�   5      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��54��6T   $��
153,64,0,0q�6`   $	��Top=�6t   $	��448��6�   �� 5   
   -   5         ��Name$ label��5      $'��!ค้นหาวันที่��6   $
��Left=�65   $��
159,43,0,0q�6P   $	��Top=�6d   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	datePick1��5      $
��Left=�6(   $��
200,84,0,0q�6C   $	��Top=�6W   $	��140��6o     5   
   -   5        $ 	datePick2��5      $
��Left=�6(   $��
382,84,0,0q�6C   $	��Top=�6W   $	��138��6o   �� 5    
   -   5        $ label1��5       $��	จาก��6    $
��Left=�6.   $��
170,82,0,0q�6I   $	��Top=�6]   �� 5!   
   -   5        $ label2��5!      $��	ถึง��6    $
��Left=�6.   $��
353,82,0,0q�6I   $	��Top=�6]   �� 5"   
   -	   5         ��Name$ Search��5"      $��ค้นหา��6!   $
��Left=�61   $��
536,87,0,0q�6L   $	��Top=�6`   $��58��6x   6�   �� 5#   
   -
   5        $ 	bt_Delete��5#      $��ลบ��6$   $
��Left=�61   $��643,414,0,0q�6L   $	��Top=�6a   $��78��6y   $��30��6�   �� 5$   
   -   5        $ 	EditClick��5$      $0��*ไปยังหน้าแก้ไข��6$   $
��Left=�6=   $��152,415,0,0q�6X   $	��Top=�6m   $��75��6�   $��31��6�   6�   �� 5%   
   -   5         ��Name$ 
Searchname��5%      $
��Left=�6&   $��24��6A   $��
627,92,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $��94��6�   6�   �� 5&   
   -   5        $ label3��5&      $*��$ค้นหาพนักงาน��6    $
��Left=�67   $��
621,59,0,0q�6R   $	��Top=�6f   $	��100��6~   5(      5)      