   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	   "    Project2016App.SearchAccount   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	     � Title$0  *ค้นหารหัสบัญชี��5   	   $��417.5��6    $	��802��6/    � Icon$ iconapp.ico��6;    � 
ResizeMode$ NoResize=�6N    � WindowStartupLocation$ CenterScreen=�6e   .��5	      � ��5
   
   �� 5       �� ImageSource$ image/bg-account.jpg��6    �� Opacity$	 0.2Q�6<   .+�5   
   �� ���	#FFE8E0E0$��1q�6)   $
��Left=�6=   $��55��6X   $��18,7,0,0q�6d   $	��Top=�6v   $	��182��6�   �� 5   
   
�������$
��Left=�6!   $��9��6<   $��26,3,0,0q�6G   
�������$	��Top=�6h   $��30��6�   �� 5   
   -   5         ��Name$ label��5      $��เงื่อนไข��6   $
��Left=�62   $��	26,-4,0,0q�6M   $	��Top=�6`   $��19��6x   $��8(�6�   �� 5   
   -   5         ��Name$ cbkInfo��5      $3��-ค้นหารายละเอียด��6$   $
��Left=�6>   $��	28,16,0,0q�6Y   $	��Top=�6l   $	��101��6�   6�   �� 5   
   -   5        $ cbkCode��5      $*��$ค้นหาจากรหัส��6$   $
��Left=�6;   $��	28,38,0,0q�6V   $	��Top=�6i   $��99��6�   6�   �� 5   
   -   5        $ label1��5      $Z��Tรายละเอียดหรือรหัสที่ต้องการ��6    $
��Left=�6G   $��	205,9,0,0q�6b   $	��Top=�6u   $	��145��6�   $��10(�6�   �� 5   
   -   5         ��Name$ 	txtSearch��5      $
��Left=�6%   $��24��6@   $��
211,38,0,0q�6L   	 �� TextWrapping$
	 Wrap=�6`   $	��Top=�6t   $	��479��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dataGrid��5      $
��Left=�6%   $��	18,67,0,0q�6@   $	��Top=�6S   $	��306��6k   $	��752��6x      AutoGenerateColumns .     CanUserResizeColumns .     CanUserResizeRows .   �� SelectedIndex$ 0��6�      FrozenColumnCount$ 0��6     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     Header$$ รหัสประเภท��6�      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6�      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *typeledgerCode+   ClipboardContentBinding 6^   Z� 6�     5       .  $$ รายละเอียด��6�   $	 250 6�    .  6%   �� *typeledgerName+ 6^   Z� 6�     5       .  $ สถานะ��6}   $	 250 6�    .  6%   �� *
ledgerName+ 6Z   Z� 6�   5      5      5      