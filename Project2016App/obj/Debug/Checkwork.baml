   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	       Project2016App.Checkwork   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	   -   5          � Title$T  Nเช็คการเข้าทำงานของพนักงาน��5   	    � 
ResizeMode$ NoResize=�6,    � WindowStartupLocation$ CenterScreen=�6B    � Icon$ iconapp.ico��6g   $��537.5��6�   $	��800��6�   .��5	      � ��5
   
   �� 5       �� ImageSource$ image/bg-checkwork.jpg��6    �� Opacity$	 0.1Q�6>   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
358,18,0,0q�6B   $
��Wrap=�6V   $9��3เช็คสถานะการทำงาน��6j   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��
38,116,0,0q�6@   $	��Top=�6T   $	��272��6l   $	��732��6y      CanUserResizeColumns .  	   AutoGenerateColumns	 .  
   CanUserSortColumns
 .     CanUserReorderColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ รหัส��6b      CanUserSort .     CanUserResize .     
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *idEmp+   ClipboardContentBinding 6?   Z� 6�     5      $ ชื่อ��6d      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6r    .   .   .  6%   �� *	nameEmp+ 6A   Z� 6�     5      $ นามสกุล��6h   $	 100 6y    .   .   .  6%   �� *LastnameEmp+ 6E   Z� 6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $! มาเต็มวัน��6e   $	 100 6x    .   .   6)   �� *cbk1+ 6B   Z� 6�     5      $0 *มาครี่งวันหน้า��6e   $	 100 6}    .   .   6)   �� *cbk2+ 6B   Z� 6�     5      $0 *มาครึ่งวันหลัง��6e   $	 100 6}    .   .   6)   �� *cbk3+ 6B   Z� 6�     5      $ 	ขาด��6e   $	 100 6r    .   .   6)   �� *cbk4+ 6B   Z� 6�     5      $ หมายเหตุ��6f   $	 100 6x    .   6%   �� *	checkInfo+ 6C   Z� 6�   5      (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dateTimepicker��5      $
��Left=�6.   $��
139,81,0,0q�6J   $	��Top=�6^      SelectedDateFormat$ Short=�6v      DisplayDate$ 
2017-01-24��6�      IsTodayHighlighted . 6�   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��24��6>   $��
648,80,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��120��6�   6�   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��
522,80,0,0q�6@   $	��Top=�6T   $	��120��6l   $��24��6x   .@�5      �� $'��!แสดงทั้งหมด��6   $��25��61   $	��100��6=   �� 5      $'��!รหัสพนักงาน��6   $��25��61   $	��100��6=   �� 5      $'��!ชื่อพนักงาน��6   $��25��61   $	��100��6=   5       �� 5!   
   -   5         ��Name$ label��5!      $?��9วันที่ต้องการบันทึก��6   $
��Left=�6=   $��	39,80,0,0q�6X   $	��Top=�6k   �� 5"   
   -   5        $ label1��5"      $��ค้นหา��6    $
��Left=�60   $��
486,78,0,0q�6K   $	��Top=�6_   �� 5#   
   $
��Left=�6   $��58��6/   $��376,407,0,0q�6;   $	��Top=�6P   $��56��6h   ��5$      �� 5%      $ image/save.ico��6   5'      �� 5(   
   -	   5         ��Name$ button��5(      $�� ��6!   $
��Left=�6,   $��376,407,0,0q�6G   $	��Top=�6\   $��55��6t    J� Opacity$ 0Q�6�   $��58��6�   �� 5)   
   -
   5        $ label2��5)      $��บันทึก��6    $
��Left=�61   $��383,458,0,0q�6L   $	��Top=�6a   $
��Bold"�6y   5*      5+      