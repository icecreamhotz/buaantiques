   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	       Project2016App.Salaryemp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	   -   5          � Title$6  0เงินเดือนพนักงาน��5   	    � 
ResizeMode$ NoResize=�6"    � Icon$ iconapp.ico��68    � WindowStartupLocation$ CenterScreen=�6L   $	��660��6q   $	��964��6~   .��5	      � ��5
   
   �� 5       �� ImageSource$ image/bg-salary.jpg��6   .+�5   
   �� -   5         ��Name$ label��5      $6��0เงินเดือนพนักงาน��6   $
��Left=�6:   $��
406,12,0,0q�6U   $	��Top=�6i   $��20(�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��
32,130,0,0q�6@   $	��Top=�6T   $	��466��6l   $	��898��6y      AutoGenerateColumns .     CanUserResizeRows .  	   CanUserResizeColumns	 .  
   CanUserReorderColumns
 .  ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
columnDate��,  &System.Windows.Controls.DataGridColumn   CanUserSort .    CanUserResize .     Header$&  วัน/เดือน/ปี��5   �      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6�      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *sMonth+   ClipboardContentBinding 6}   Z� 6�     5       .    CanUserReorder .   .  $' !รหัสพนักงาน��6�   $	 200 6�    .  6%   �� *empID+ 6   Z� 6�     5       .  .  $' !ชื่อพนักงาน��6�   $	 200 6�    .  6%   �� *sName+ 6h   Z� 6�     5       .  .  $0 *นามสกุลพนักงาน��6�   $	 200 6�    .  6%   �� *	sLastname+ 6l   Z� 6�     5       .  .  $! เงินเดือน��6�   $	 200 6�    .  6%   �� *	sSalary+ 6j   Z� 6�   5      (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datePicker1��5      $
��Left=�6*   $��	87,89,0,0q�6E   $	��Top=�6X      SelectedDateFormat$ Short=�6p   $	��102��6�     5   
   -   5        $ datePicker2��5      $
��Left=�6*   $��
245,89,0,0q�6E   $	��Top=�6Y   �� 5   
   $
��Left=�6   $��23��6/   $��
355,89,0,0q�6;   $	��Top=�6O   $��22��6g   ��5      �� 5      $ image/search-128.png��6   5      �� 5   
   -   5         ��Name$ Search��5      $�� ��6!   $
��Left=�6,   $��
356,90,0,0q�6G   $	��Top=�6[   $��20��6s    J� Opacity$ 0Q�6~   $��22��6�   6�   �� 5    
   -   5        $ label1��5       $#��จากวันที่ :��6    $
��Left=�66   $��	34,88,0,0q�6Q   $	��Top=�6d   �� 5!   
   -	   5        $ label2��5!      $#��ถึงวันที่ :��6    $
��Left=�66   $��
194,88,0,0q�6Q   $	��Top=�6e   5"      5#      