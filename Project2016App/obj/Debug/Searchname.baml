   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	       Project2016App.Searchname   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	     � Title$!  ค้นหาชื่อ��5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�61   $	��413��6V   $	��682��6c    � Icon$ iconapp.ico��6o   .��5	      � ���	#FFFF8989.+�5
   
   �� -   5         ��Name$ label��5
      $#��ค้นหาชื่อ :��6   $
��Left=�65   $��16,9,0,0q�6P   $	��Top=�6b   �� 5   
   -   5         ��Name$ 	SearchBox��5      $
��Left=�6%   $��23��6@   $��	76,11,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��591��6�   ���	#FF87EA116�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��7,43,0,0q�6@   $	��Top=�6R   $	��327��6j   $	��661��6w      AutoGenerateColumns .  	   CanUserResizeColumns	 .  
   CanUserResizeRows
 .   �� SelectedIndex$ 0��6�      FrozenColumnCount$ 0��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     Header$$ รหัสลูกค้า��6x      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *cusID+   ClipboardContentBinding 6U   Z� 6�     5       .  $ ชื่อ��6z   $	 100 6�    .  6%   �� *	cusName+ 6W   Z� 6�     5       .  $ นามสกุล��6{   $	 100 6�    .  6%   �� *
cusLname+ 6X   Z� 6�     5       .  $ ที่อยู่��6}   $	 100 6�    .  6%   �� *
cusAddress+ 6Z   Z� 6�     5       .  $3 -รหัสบัตรประชาชน��6z   $	 100 6�    .  6%   �� *	cusCard+ 6W   Z� 6�     5       .  $' !ป้ายทะเบียน��6{   $	 100 6�    .  6%   �� *
cusPlate+ 6X   Z� 6�     5       .  $ เบอร์โทร��6y   $	 100 6�    .  6%   �� *cusTel+ 6V   Z� 6�   5      5      5      