   M S B A M L   `   `   `  ����R  N18_EF_EgyATobbKapcsolat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:_18_EF_EgyATobbKapcsolat_18_EF_EgyATobbKapcsolat  5   	   )    #_18_EF_EgyATobbKapcsolat.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:_18_EF_EgyATobbKapcsolat     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
DG_tanulok��5         AutoGenerateColumns$ False��6'      
IsReadOnly$
 True��6C      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Név��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *	tanuloNev+  5      $ Születési dátum��6%    6>   �� *szuletesiDatum+	 �� StringFormat$	 {0:yyyy.MM.dd}��  5      $ Osztály��6%    66   �� *Osztaly.osztalyNev+  5      $ Osztályfőnök��6%    6;   �� *Osztaly.osztalyFonok+5        5   
   -   5        $ 
DG_osztaly��5      $ False��6'   $
 True��6C   $��1��6U    5        5      $ Osztály��6%    66   �� *
osztalyNev+  5       $ Osztályfőnök��6%    6;   �� *osztalyFonok+4  .System.Windows.Controls.DataGridTemplateColumn  5!      $ Tanulók��6)   
   
IsReadOnly$

 True��6:      CellTemplate 5"      �� 5#      .R�5$      �� ��6+   �� *Tanulo+��5%   "   �� 5&   &   .R�5'   *   ��  �� Orientation$ 
Horizontal=�65   .+�5(   .   �� ��68   �� *	tanuloNev+$	 
Név: {0},���� 5)   .   $��5,0,0,0q�6�   ��68   �� *szuletesiDatum+$"	 Szül.dátum: {0:yyyy.MM.dd}��6�   5*   +   5+   '   5-      5.      50      52        54   
   -   5        $ DG_lekerdezes��54   #   $��1��6   $
 True��6:   $
 True��55      57      �� 59   
   $��1��6   $��1��6"   .+�5:      �� -   5         ��Name$ CBO_osztalyok��5:      $	��120��6.   $��5q�6:    �� DisplayMemberPath$ 
osztalyNev��5;      5<        5>      -   5        $ DG_lista��5>      $
 True��6)   $
 True��6D   $	��160��5?      5@      5A      5B      