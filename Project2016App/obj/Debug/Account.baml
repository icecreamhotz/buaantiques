   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	       Project2016App.Account   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	   -   5          � Title$B  <บันทึกรายการประจำวัน��5   	   $	��560��6&   $	��672��63    � 
ResizeMode$ NoResize=�6?    � Icon$ iconapp.ico��6V    � WindowStartupLocation$ CenterScreen=�6i   
�������
�������.��5	      � ��5
   
   �� 5       �� ImageSource$ image/bg-account.jpg��6    �� Opacity$	 0.2Q�6<   .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��486��6T   $��	46,22,0,0q�6a   $	��Top=�6t   $	��576��6�   �� 5   
   
�������$
��Left=�6!   $��20��6<   $��	75,46,0,0q�6H   
�������$	��Top=�6j   $	��103��6�   �� 5   
   -   5         ��Name$ 
label_Copy��5      $@��:บันทึกรายรับ-รายจ่าย��6$   $
��Left=�6C   $��	73,42,0,0q�6^   $	��Top=�6q   $	��107��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��459��6T   $��	61,39,0,0q�6a   $	��Top=�6t   $	��545��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datePicker1��5      $
��Left=�6*   $��
178,93,0,0q�6E   $	��Top=�6Y   $��26��6q   $	��116��6}   �� 5   
   -   5        $ label1_Copy��5      $��วันที่ : ��6%   $
��Left=�69   $��
136,92,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $ label1_Copy1��5      $$��รหัสบัญชี : ��6&   $
��Left=�6=   $��113,132,0,0q�6X   $	��Top=�6m   $��60��6�   �� 5   
   -   5         ��Name$ 
txtaccCode��5      $
��Left=�6&   $��23��6A   $��178,136,0,0q�6M   	 �� TextWrapping$
	 Wrap=�6b   $	��Top=�6v   $	��117��6�   �� 5   
   -   5        $ label1_Copy2��5      $'��!รายละเอียด : ��6&   $
��Left=�6>   $��106,177,0,0q�6Y   $	��Top=�6n   $��66��6�   �� 5   
   -   5        $ label1_Copy3��5      $)��#ประเภทบัญชี :��6&   $
��Left=�6>   $��
99,223,0,0q�6Y   $	��Top=�6m   $��74��6�   �� 5   
   -	   5        $ label1_Copy4��5      $��รายการ : ��6&   $
��Left=�6:   $��122,267,0,0q�6U   $	��Top=�6j   $��51��6�   �� 5   
   -
   5        $ txtItem1��5      $
��Left=�6$   $��23��6?   $��178,271,0,0q�6K   $
	 Wrap=�6`   $	��Top=�6t   $	��404��6�   �� 5   
   -   5        $ label1_Copy5��5      $,��&จำนวนเงินรับ :��6&   $
��Left=�6?   $��
99,322,0,0q�6Z   $	��Top=�6n   $��75��6�   �� 5   
   -   5        $ label1_Copy6��5      $/��)จำนวนเงินจ่าย :��6&   $
��Left=�6@   $��
93,364,0,0q�6[   $	��Top=�6o   $��81��6�   �� 5   
   -   5        $ txtRub��5      $
��Left=�6"   $��23��6=   $��178,326,0,0q�6I   $
	 Wrap=�6^   $	��Top=�6r   $	��120��6�   
 �� TextAlignment$
 Right=�6�   6�   �� 5   
   -   5        $ txtPay��5      $
��Left=�6"   $��23��6=   $��178,367,0,0q�6I   $
	 Wrap=�6^   $	��Top=�6r   $	��120��6�   $
 Right=�6�   6�   �� 5   
   -   5         ��Name$ showtxtaccItem��5      $
��Left=�6,   $��178,182,0,0q�6G   $
��Wrap=�6\   $	��Top=�6p   $	��115��6�   �� 5   
   -   5        $ showtxtaccStatus��5      $
��Left=�6.   $��178,226,0,0q�6I   $
��Wrap=�6^   $	��Top=�6r   $	��115��6�   $��20��6�   �� 5   
   $
��Left=�6   $��51��6/   $��325,425,0,0q�6;   $	��Top=�6P   $��51��6h   ��5       �� 5!      $ image/save.ico��6   5#      �� 5$   
   $
��Left=�6   $��24��6/   $��302,136,0,0q�6;   $	��Top=�6P   $��22��6h   ��5%      �� 5&      $ image/search-128.png��6   5(      �� 5)   
   -   5         ��Name$ btInsert��5)      $�� ��6#   $
��Left=�6.   $��329,426,0,0q�6I   $	��Top=�6^   $��45��6v   $��50��6�    J� Opacity$ 0Q�6�   ��6�   Z� 6�   �� 5*   
   -   5        $ label��5*      $��บันทึก��6   $
��Left=�60   $��330,471,0,0q�6K   $	��Top=�6`   $
��Bold"�6x   �� 5+   
   -   5        $ btSearch��5+      $�� ��6#   $
��Left=�6.   $��300,136,0,0q�6I   $	��Top=�6^   $��25��6v   $��23��6�   
�������$ 0Q�6�   5,      5-      