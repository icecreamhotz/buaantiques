   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	       Project2016App.Stock   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	   -   5          � Title$'  !สต๊อคสินค้า��5   	   $	��450��6   $��741.5��6*    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6O    � Icon$ iconapp.ico��6t   .��5	      � ��5
   
   �� 5       �� ImageSource$ image/bg-editproduct.png��6    �� Opacity$	 0.2Q�6@   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $
��Left=�6%   $��	40,66,0,0q�6@   $	��Top=�6S   $	��332��6k   $	��662��6x      AutoGenerateColumns .     CanUserResizeRows .  	   CanUserResizeColumns	 .  ��6�   Z� 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     Header$ รหัส��6z      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	proCode+   ClipboardContentBinding 6W   Z� 6�     5       .  $$ ชื่อสินค้า��6z   $	 180 6�    .  6%   �� *	proName+ 6W   Z� 6�     5       .  $' !ราคารับซื้อ��6~   $	 100 6�    .  6%   �� *proPricebuy+ 6[   Z� 6�     5       .  $ ราคาขาย��6   $	 100 6�    .  6%   �� *proPricesell+ 6\   Z� 6�     5       .  $ หน่วยนับ��6   $	 100 6�    .  6%   �� *typenameUnit+ 6\   Z� 6�     5       .  $ ประเภท��6|   $	 100 6�    .  6%   �� *	typepName+ 6Y   Z� 6�     5       .  $ จำนวน��6}   $ 80 6�    .  6%   �� *
stockTotal+ 6Z   Z� 6�   5      �� 5   
   -   5         ��Name$ label��5      $&�� ชื่อสินค้า :��6   $
��Left=�66   $��	34,16,0,0q�6Q   $	��Top=�6d   �� 5   
   -   5         ��Name$ 	txtSearch��5      $
��Left=�6%   $��22��6@   $��	94,20,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��210��6�   6�   �� 5   
   -   5         ��Name$ button��5      $'��!แสดงทั้งหมด��6!   $
��Left=�67   $��
628,19,0,0q�6R   $	��Top=�6f   $��74��6~   $��22��6�   6�   5      5      