   M S B A M L   `   `   `  ����S  O19_EF_TobbATobbKapcsolat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:_19_EF_TobbATobbKapcsolat_19_EF_TobbATobbKapcsolat  5   	   *    $_19_EF_TobbATobbKapcsolat.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:_19_EF_TobbATobbKapcsolat     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��5q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DG_eredmenyek��5      $	��150��6.      AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Tanuló��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   )   �� *Tanulo.tanuloNev+  5      $ Teszt��6)    5   )   �� *Teszt.tesztMegnevezes+  5      $ 	Eredmény��6)    5   )   �� *
eredmeny+  5      $ Dátum��6)    5   )   �� *datum+ �� StringFormat$ 
yyyy.MM.dd��5      �� 5       $��Új teszt eredmény��6   .��5!      �� .+�5"      �� 	 �� Orientation$	 
Horizontal=�6!   $��5q�6:   .+�5#      �� $��Tanuló:��6    $	��120��62   �� 5$      -   5        
 ��Name$
 CBO_tanulok��5$   #   $	��150��68    �� DisplayMemberPath$ 	tanuloNev��5%   #   5&      �� 5'      $	 
Horizontal=�6!   $��5q�6:   .+�5(      �� $��Teszt:��6    $	��120��61   �� 5)      -   5        $
 CBO_tesztek��5)   #   $	��150��68   $ tesztMegnevezes��5*   #   5+      �� 5,      $	 
Horizontal=�6!   $��5q�6:   .+�5-      �� $��
Eredmény:��6    $	��120��64   �� 5.      -   5        $
 CBO_eredmeny��5.   #   $��50��69   .@�5/      �� $��1��6+   �� 50      $��2��6+   �� 51      $��3��6+   �� 52      $��4��6+   �� 53      $��5��6+   54      55      �� 56      $	 
Horizontal=�6!   $��5q�6:   .+�57      �� $��Dátum:��6    $	��120��61   (  "System.Windows.Controls.DatePicker  58      -   5          Name$ DP_datum��58   %   $	��150��67   59      �� 5:      -   5         ��Name$ 
BTN_mentes��5:      $��   Mentés   ��61   $
��Left=�6H   $��
125,15,5,5q�5;      $��5q�61   5<      5=      5>      5?      �� 5A   
   $��1��6   $��5q�6%   .+�5B        -   5        $ DG_lekerdezesTanulo��5B      $
 True��64   $
 True��5C      $	��150��5D      5E      �� 5F      $	 
Horizontal=�6   .+�5G      �� $��Tanuló:��6   �� 5H      -   5        $
 CBO_tanulok2��5H      $	��150��61   $ 	tanuloNev��5I      5J      5K        5N      -	   5        $ DG_lekerdezesTeszt��5N      $
 True��63   $
 True��5O      $	��150��5P      5Q      �� 5R      $	 
Horizontal=�6   .+�5S      �� $��Teszt:��6   �� 5T      -
   5        $
 
CBO_teszt2��5T      $	��150��6/   $ tesztMegnevezes��5U      5V      5W      5Y      5Z      5[      