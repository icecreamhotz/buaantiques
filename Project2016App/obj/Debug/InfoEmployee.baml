   M S B A M L   `   `   `  ����I  EProject2016App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project2016AppProject2016App  5   	   !    Project2016App.InfoEmployee   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project2016App     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$-  'ข้อมูลพนักงาน��5	   
   $	��759��6    $
��1378��6-    � Icon$ iconapp.ico��6:    � 
ResizeMode$ NoResize=�6M    � WindowStartupLocation$ CenterScreen=�6c    � WindowState$ 	Maximized=�6�   .��5
      � ��5   
   �� 5       �� ImageSource$ image/employee.png��6    �� Opacity$
 0.02Q�6:   .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��372��6T   $��	15,60,0,0q�6a   $	��Top=�6t   $	��454��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��268��6T   $��
13,454,0,0q�6a   $	��Top=�6u   $
��1348��6�   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $y�Hidden=�6>   $��23��6R   $��
28,462,0,0q�6^    �� TextWrapping$
 Wrap=�6r   $	��Top=�6�   $	��120��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 dataGrid��5      $
��Left=�6%   $��
25,470,0,0q�6@   $	��Top=�6T   $	��241��6l   $
��1327��6y   
   AutoGenerateColumns
 .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$' !ชื่อพนักงาน��6A      CanUserResize .     
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 132 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	nameEmp+   ClipboardContentBinding 6V   Z� 6�     5      $0 *นามสกุลพนักงาน��6E    .   . $	 132 6�    6%   �� *lastnameEmp+ 6]   Z� 6�     5      $ เบอร์โทร��6@    .   . $	 132 6�    6%   �� *telEmp+ 6R   Z� 6�     5      $3 -รหัสบัตรประชาชน��6C    .   . $	 132 6�    6%   �� *	idcardEmp+ 6\   Z� 6�     5      $ 	เพศ��6@    .   . $	 132 6�    6%   �� *sexEmp+ 6M   Z� 6�     5      $ ที่อยู่��6D    .   . $	 132 6�    6%   �� *
addressEmp+ 6U   Z� 6�     5      $ 	ถนน��6A    .   . $	 132 6�    6%   �� *	roadEmp+ 6N   Z� 6�     5      $ หมู่��6@    .   . $	 132 6�    6%   �� *mooEmp+ 6N   Z� 6�     5      $ จังหวัด��6G    .   . $	 132 6�    6%   �� *PROVINCE_NAME+ 6X   Z� 6�     5      $ อำเภอ��6E    .   . $	 132 6�    6%   �� *AMPHUR_NAME+ 6T   Z� 6�     5      $ ตำบล��6G    .   . $	 132 6�    6%   �� *DISTRICT_NAME+ 6U   Z� 6�     5      $* $รหัสไปรษณีย์��6D    .   . $	 132 6�    6%   �� *
zipcodeEmp+ 6Z   Z� 6�     5      $* $รหัสไปรษณีย์��6?    .   . $ 0 6�    6%   �� *idEmp+ 6U   Z� 6�   5!      �� 5"   
   -   5         ��Name$ label2_Copy��5"      $��ชื่อ :��6%   $
��Left=�66   $��
259,72,0,0q�6Q   $	��Top=�6e   $��26��6}   $��29��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5#      V� 5$      .~�5%      �� �� 5&      �� 5'       �� Angle$ 0.155Q�6&   T� 5(      5)      5+      �� 5,   
   -   5        $ label2_Copy1��5,      $��นามสกุล :��6&   $
��Left=�6:   $��234,132,0,0q�6U   $	��Top=�6j   $��26��6�   $��56��6�   �� 5-   
   -   5        $ label2_Copy2��5-      $ ��เบอร์โทร :��6&   $
��Left=�6;   $��235,190,0,0q�6V   $	��Top=�6k   $��26��6�   $��56��6�   �� 5.   
   -   5        $ label2_Copy3��5.      $5��/รหัสบัตรประชาชน :��6&   $
��Left=�6B   $��193,249,0,0q�6]   $	��Top=�6r   $��26��6�   $��98��6�   �� 5/   
   -   5        $ label2_Copy4��5/      $��เพศ :��6&   $
��Left=�66   $��
53,250,0,0q�6Q   $	��Top=�6e   $��26��6}   $��40��6�   �� 50   
   -	   5         ��Name$ cbkMale��50      $��	ชาย��6$   $
��Left=�62   $��
89,256,0,0q�6M   $	��Top=�6a   6y   �� 51   
   -
   5        $ 	cbkFemale��51      $��หญิง��6&   $
��Left=�65   $��143,256,0,0q�6P   $	��Top=�6e   6}   �� 52   
   -   5        $ label2_Copy5��52      $&�� บ้านเลขที่ :��6&   $
��Left=�6=   $��
29,293,0,0q�6X   $	��Top=�6l   $��26��6�   $��66��6�   �� 53   
   -   5         ��Name$ 
cbProvince��53      $
��Left=�6'   $��
93,367,0,0q�6B   $	��Top=�6V   $	��120��6n   6�   �� 54   
   -   5        $ cbAmphur��54      $
��Left=�6%   $��303,367,0,0q�6@   $	��Top=�6U   $	��121��6m   6�   �� 55   
   -   5        $ txtLastname��55      $
��Left=�6'   $��24��6B   $��292,134,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��164��6�   �� 56   
   -   5        $ txtName��56      $
��Left=�6#   $��24��6>   $��
293,74,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��162��6�   �� 57   
   -   5        $ 
txtAddress��57      $
��Left=�6&   $��26��6A   $��
93,293,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 58   
   -   5        $ label2_Copy6��58      $��จังหวัด :��6&   $
��Left=�6:   $��
43,365,0,0q�6U   $	��Top=�6i   $��26��6�   $��56��6�   �� 59   
   -   5        $ label2_Copy7��59      $��อำเภอ :��6&   $
��Left=�68   $��254,364,0,0q�6S   $	��Top=�6h   $��26��6�   $��56��6�   �� 5:   
   -   5        $ 
cbDistrict��5:      $
��Left=�6'   $��
93,402,0,0q�6B   $	��Top=�6V   $	��120��6n   6�   �� 5;   
   -   5        $ label2_Copy8��5;      $��ตำบล :��6&   $
��Left=�67   $��
47,400,0,0q�6R   $	��Top=�6f   $��26��6~   $��56��6�   �� 5<   
   -   5        $ label2_Copy9��5<      $,��&รหัสไปรษณีย์ :��6&   $
��Left=�6?   $��225,330,0,0q�6Z   $	��Top=�6o   $��26��6�   $��76��6�   �� 5=   
   -   5        $ 
txtZipcode��5=      $
��Left=�6&   $��26��6A   $��303,330,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��121��6�   �� 5>   
   -   5        $ label��5>      $-��'ข้อมูลพนักงาน��6   $
��Left=�67   $��
173,14,0,0q�6R   $	��Top=�6f   $
��Bold"�6~   $��15(�6�   �� 5?   
   
���   �$��1q�6%   $
��Left=�69   $	��145��6T   $��	49,66,0,0q�6a   $	��Top=�6t   $	��151��6�   ._�5@      �� -   5         ��Name$ image1��5@      $
��Left=�6$   $	��143��6?   $	��Top=�6L   $	��149��6d   $��	-1,-1,0,0q�6p   5A      �� 5B   
   $
��Left=�6   $	��100��6/   $��
504,38,0,0q�6<   
�������$	��Top=�6_   $	��100��6w   ��5C      �� 5D      $ image/add-employee.png��6   5F      �� 5G   
   -   5         ��Name$ 
Insertinfo��5G      $�� ��6%   $
��Left=�60   $��
502,36,0,0q�6K   $	��Top=�6_   $	��102��6w   $	��101��6�   
������� J� Opacity$ 0Q�6�   �� 5H   
   $
��Left=�6   $	��100��6/   $��504,314,0,0q�6<   
�������$	��Top=�6`   $	��100��6x   ��5I      �� 5J      $ image/delete.png��6   5L      �� 5M   
   -   5        $ Delete��5M      $�� ��6!   $
��Left=�6,   $��503,309,0,0q�6G   $	��Top=�6\   $��96��6t   $	��102��6   ��. $ 0Q�6�   
�������6�   �� 5N   
   $
��Left=�6   $	��100��6/   $��510,179,0,0q�6<   
�������$	��Top=�6`   $	��100��6x   ��5O      �� 5P      $ image/edit.png��6   5R      �� 5S   
   -   5        $ 
EditButton��5S      $�� ��6%   $
��Left=�60   $��513,176,0,0q�6K   $	��Top=�6`   $��99��6x   $	��101��6�   
�������$ 0Q�6�   �� 5T   
   -   5        $ label1��5T      $��แก้ไข��6    $
��Left=�60   $��523,278,0,0q�6K   $	��Top=�6`   $��15(�6x   $
��Bold"�6�   �� 5U   
   -   5        $ label1_Copy��5U      $��ลบข้อมูล��6%   $
��Left=�68   $��521,409,0,0q�6S   $	��Top=�6h   $��15(�6�   $
��Bold"�6�   �� 5V   
   -   5        $ label1_Copy1��5V      $'��!เพิ่มข้อมูล��6&   $
��Left=�6<   $��517,139,0,0q�6W   $	��Top=�6l   $��15(�6�   $
��Bold"�6�   �� 5W   
   
���   �$��1q�6%   $
��Left=�69   $	��235��6T   $��659,200,0,0q�6a   $	��Top=�6v   $	��341��6�   �� 5X   
   -   5        $ cbkSearchname��5X      $0��*ค้นหาเฉพาะชื่อ��6*   $
��Left=�6C   $��670,211,0,0q�6^   $	��Top=�6s   6�   �� 5Y   
   -    5        $ cbkSearchidcard��5Y      $Q��Kค้นหาเฉพาะรหัสบัตรประชาชน��6,   $
��Left=�6P   $��670,240,0,0q�6k   $	��Top=�6�   6�   �� 5Z   
   -!   5        $ cbkSearchsex��5Z      $��	เพศ��6)   $
��Left=�67   $��670,268,0,0q�6R   $	��Top=�6g   6   	� 5[   
   -"   5         	�Name$ rbtMale��5[      $��เพศชาย��6'   $
��Left=�68   $��687,294,0,0q�6S   $	��Top=�6h   6�   	� 5\   
   -#   5        $ 	rbtFemale��5\      $��เพศหญิง��6)   $
��Left=�6;   $��687,315,0,0q�6V   $	��Top=�6k   6�   �� 5]   
   -$   5        $ 	txtSearch��5]      $
��Left=�6%   $��23��6@   $��725,403,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��225��6�   �� 5^   
   -%   5        $ cbkSearchprovince��5^      $9��3ค้นหาเฉพาะจังหวัด��6.   $
��Left=�6J   $��671,342,0,0q�6e   $	��Top=�6z   6�   �� 5_   
   -&   5        $ label2��5_      $)��#ค้นหาที่นี่ :��6    $
��Left=�68   $��664,401,0,0q�6S   $	��Top=�6h   �� 5`   
   -'   5        $ label3��5`      $3��-เครื่องมือค้นหา��6    $
��Left=�6:   $��767,169,0,0q�6U   $	��Top=�6j   $��15(�6�   $
��Bold"�6�   �� 5a   
   -(   5        $ cbkSearchAll��5a      $'��!แสดงทั้งหมด��6)   $
��Left=�6?   $��671,370,0,0q�6Z   $	��Top=�6o   6�   �� 5b   
   $
��Left=�6   $��25��6/   $��960,401,0,0q�6;   
�������$	��Top=�6_   $��25��6w   ��5c      �� 5d      $ image/search-128.png��6   5f      �� 5g   
   -)   5        $ Search_Button��5g      $��Button��6(   $
��Left=�69   $��957,399,0,0q�6T   $	��Top=�6i   $��32��6�   $��28��6�   
�������
�������$ 0Q�6�   6�   %  Xceed.Wpf.Toolkit.MaskedTextBox  5h   
   -*   5          Name$ txtCard��5h         Mask$ 0-0000-00000-00-0��6.    �� 
CaretIndex$ 0��6G   $��291,258,963,461q�6W   $��12(�6p     5i   
   -+   5        $ txtTel��5i      $ 000-000-0000��6-   $ 0��6A   $��289,199,965,520q�6Q   $��12(�6j   �� 5j   
   -,   5        $ label2_Copy10��5j      $��ถนน :��6'   $
��Left=�67   $��261,292,0,0q�6R   $	��Top=�6g   $��26��6   $��40��6�   �� 5k   
   --   5        $ txtRoad��5k      $
��Left=�6#   $��26��6>   $��303,292,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��122��6�   �� 5l   
   -.   5        $ label2_Copy11��5l      $��หมู่ :��6'   $
��Left=�68   $��
57,330,0,0q�6S   $	��Top=�6g   $��26��6   $��34��6�   �� 5m   
   -/   5        $ txtMoo��5m      $
��Left=�6"   $��26��6=   $��
93,330,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��120��6�   �� 5n   
   -0   5        $ Btnchoosefile��5n      $*��$เลือกไฟล์ภาพ��6(   $
��Left=�6?   $��
87,215,0,0q�6Z   $	��Top=�6n   $��75��6�   
�������6�   �� 5o   
   -1   5         ��Name$ 
ShowpicUrl��5o      $
��Left=�6(   $��302,407,0,0q�6C   $
��Wrap=�6X   $	��Top=�6l   $	��126��6�   $ 0Q�6�   5p      5q      