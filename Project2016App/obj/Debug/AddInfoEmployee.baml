   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   I EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App 5   	   $   Project2016App.AddInfoEmployee   5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   .localclr-namespace:Project2016App     5   	     �Language$  th-TH�5
   �    � Title$< 6เพิ่มข้อมูลพนักงาน��6	   $	��759��6$   $
��1378��61    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T    � Icon$ iconapp.ico��6y    � WindowState$ 	Maximized=�6�   .��5      � ��5   
   �� 5       �� ImageSource$ image/bgemployee.jpg��6    �� Opacity$	 0.1Q�6<    � RowDefinitions 5   
   �� 5      .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��612��6T   $��	32,96,0,0q�6a   $	��Top=�6t   $
��1306��6�   ��5      �� 5      	 �� Color$	 White��6"   $ 0Q�60   5      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��370��6T   $��
76,308,0,0q�6a   $	��Top=�6u   $
��1219��6�   ��5      �� 5      $	 White��6"   $ 0Q�60   5      �� 5   
   -   5        
 ��Name$
 
ChooseFile��5      $'��!ค้นหารูปภาพ��6%   $
��Left=�6;   $��642,268,0,435q�6V   $��Center=�6m   $��74��6�   $��27��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��145��6T   $��607,112,0,0q�6a   $	��Top=�6v   $	��151��6�   ._�5      �� -   5         ��Name$ image1��5      $
��Left=�6$   $	��143��6?   $	��Top=�6L   $	��149��6d   5      �� 5    
   -   5         ��Name$ label1��5       $B��<ข้อมูลส่วนตัวพนักงาน��6    $
��Left=�6?   $��
78,281,0,0q�6Z   $	��Top=�6n   $��26��6�   $	��107��6�   �� 5!   
   -   5        $ label2��5!      $��ชื่อ :��6    $
��Left=�61   $��139,337,0,0q�6L   $	��Top=�6a   $��26��6y   $��29��6�   �� 5"   
   -   5        $ label2_Copy��5"      $��นามสกุล :��6%   $
��Left=�69   $��355,335,0,0q�6T   $	��Top=�6i   $��26��6�   $��55��6�   �� 5#   
   -   5        $ label2_Copy1��5#      $ ��เบอร์โทร :��6&   $
��Left=�6;   $��595,335,0,0q�6V   $	��Top=�6k   $��26��6�   $��55��6�   �� 5$   
   -   5        $ label2_Copy2��5$      $5��/รหัสบัตรประชาชน :��6&   $
��Left=�6B   $��838,334,0,0q�6]   $	��Top=�6r   $��26��6�   $��98��6�   �� 5%   
   -   5        $ label2_Copy3��5%      $��เพศ :��6&   $
��Left=�66   $��135,402,0,0q�6Q   $	��Top=�6f   $��26��6~   $��56��6�   �� 5&   
   -	   5         ��Name$ cbkMale��5&      $��	ชาย��6$   $
��Left=�62   $��181,408,0,0q�6M   $	��Top=�6b   6z   �� 5'   
   -
   5        $ 	cbkFemale��5'      $��หญิง��6&   $
��Left=�65   $��254,408,0,0q�6P   $	��Top=�6e   6}   �� 5(   
   -   5        $ label2_Copy4��5(      $&�� บ้านเลขที่ :��6&   $
��Left=�6=   $��351,401,0,0q�6X   $	��Top=�6m   $��26��6�   $��66��6�   �� 5)   
   -   5         ��Name$ 
cbProvince��5)      $
��Left=�6'   $��174,464,0,0q�6B   $	��Top=�6W   $	��120��6o   6�   �� 5*   
   -   5        $ cbAmphur��5*      $
��Left=�6%   $��174,514,0,0q�6@   $	��Top=�6U   $	��120��6m   6y   �� 5+   
   -   5         ��Name$ txtLastname��5+      $
��Left=�6'   $��25��6B   $��412,338,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��163��6�   �� 5,   
   -   5        $ txtName��5,      $
��Left=�6#   $��25��6>   $��173,339,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��163��6�   �� 5-   
   -   5        $ 
txtAddress��5-      $
��Left=�6&   $��25��6A   $��413,402,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��237��6�   �� 5.   
   -   5        $ label2_Copy5��5.      $��จังหวัด :��6&   $
��Left=�6:   $��123,462,0,0q�6U   $	��Top=�6j   $��26��6�   $��56��6�   �� 5/   
   -   5        $ label2_Copy6��5/      $��อำเภอ :��6&   $
��Left=�68   $��124,507,0,0q�6S   $	��Top=�6h   $��26��6�   $��56��6�   �� 50   
   -   5        $ 
cbDistrict��50      $
��Left=�6'   $��174,556,0,0q�6B   $	��Top=�6W   $	��120��6o   6{   �� 51   
   -   5        $ label2_Copy7��51      $��ตำบล :��6&   $
��Left=�67   $��126,554,0,0q�6R   $	��Top=�6g   $��26��6   $��56��6�   �� 52   
   -   5        $ label2_Copy8��52      $,��&รหัสไปรษณีย์ :��6&   $
��Left=�6?   $��
94,597,0,0q�6Z   $	��Top=�6n   $��26��6�   $��76��6�   �� 53   
   -   5        $ 
txtZipcode��53      $
��Left=�6&   $��25��6A   $��174,598,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��121��6�   �� 54   
   -   5        $ label2_Copy9��54      $/��)ที่อยู่รูปภาพ :��6&   $
��Left=�6@   $��1005,640,0,0q�6[   $	��Top=�6q   $��26��6�   $��76��6�   �� 55   
   -   5        $ 
showPicUrl��55      $
��Left=�6&   $��26��6A   $��1074,641,0,0q�6M   $
 Wrap=�6c   $	��Top=�6w   $	��202��6�   �� 56   
   $
��Left=�6   $��69��6/   $��34,9,0,0q�6;   
�������$	��Top=�6\   $��76��6t   ��57      �� 58      $ image/save.ico��6   5:      �� 5;   
   -   5        $
 Savetodb��5;      $��Button��6#   $
��Left=�64   $��34,8,0,0q�6O   $	��Top=�6a   $��74��6y   $��66��6�   
������� J� Opacity$ 0Q�6�   6�   �� 5<   
   -   5        $ label��5<      $��บันทึก��6   $
��Left=�60   $��	42,69,0,0q�6K   $	��Top=�6^   $��16(�6v   $
��Bold"�6�   $��32��6�   $��57��6�   �� 5=   
   $
��Left=�6   $��69��6/   $��	136,9,0,0q�6;   
�������$	��Top=�6]   $��76��6u   ��5>      �� 5?      $ image/cleardata.png��6   5A      �� 5B   
   -   5        $
 	Cleardata��5B      $��Button��6$   $
��Left=�65   $��	136,8,0,0q�6P   $	��Top=�6c   $��74��6{   $��66��6�   
�������$ 0Q�6�   6�   �� 5C   
   -   5        $ 
label_Copy��5C      $$��ล้างข้อมูล��6$   $
��Left=�69   $��
138,68,0,0q�6T   $	��Top=�6h   $��16(�6�   $
��Bold"�6�   $��32��6�   $��79��6�   �� 5D   
   -   5        $ label2_Copy10��5D      $��ถนน :��6'   $
��Left=�67   $��666,400,0,0q�6R   $	��Top=�6g   $��26��6   $��41��6�   �� 5E   
   -   5        $ label2_Copy11��5E      $��หมู่ :��6'   $
��Left=�68   $��905,399,0,0q�6S   $	��Top=�6h   $��26��6�   $��40��6�   �� 5F   
   -   5        $ txtMoo��5F      $
��Left=�6"   $��25��6=   $��947,402,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��214��6�   �� 5G   
   -    5        $ txtRoad��5G      $
��Left=�6#   $��25��6>   $��714,402,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��171��6�   %  Xceed.Wpf.Toolkit.MaskedTextBox  5I   
   -!   5          Name$ txtCard��5I         Mask$ 0-0000-00000-00-0��6/    �� 
CaretIndex$ 0��6H   $��940,337,314,382q�6X   $��12(�6q     5J   
   -"   5        $ txtTel��5J      $ 000-000-0000��6-   $ 0��6A   $��658,337,606,382q�6R   $��12(�6k   5K      5L      