   M S B A M L   `   `   `  ����H  D20_EF_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:_20_EF_Library.Pages_20_EF_Library.Pages  5      '    !_20_EF_Library.Pages.PageBookList   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:_20_EF_Library.Pages     5        N� Title$  PageBookList��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Cím:��6   $��5q�6#   �� 5      -   5         ��Name$ TB_cim��5      $	��150��6&   $��5q�62   �� 5      $��Szerző:��6   $��5q�6&   �� 5      -   5         ��Name$ CBO_szerzok��5      $	��150��6,   $��5q�68    �� DisplayMemberPath$ Fullname��5      �� 5      $��Kategória:��6   $��5q�6)   �� 5      -   5        $ CBO_kategoriak��5      $	��150��6/   $��5q�6;   $
 Name��5      �� 5      -   5         ��Name$ BTN_kereses��5      $��Keresés��6*   $��25,5,5,5q�5      $��5q�5      5       5!      �� 5$   
   $��1��6   .+�5%      �� $��	Könyvek:��6   $��5q�6'   $
��Bold"�62   &   System.Windows.Controls.DataGrid  5&      -   5          Name$ DG_konyvlista��5&      $��5q�6.   $	��300��69      AutoGenerateColumns$ False��5'      	   
IsReadOnly$
	 True��63   
   Columns
 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$
 Cím��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Name+6O     5*      $ 
Oldalszám��6)   $ 70 6Z    6<   �� *	Pagecount+6Z     5+      $ Szerző��6)   $	 200 6]    69   �� *Author.Fullname+6]     5,      $ 
Kategória��6)   $ * 6[    6<   �� *
Types.Name+6[   5.      5/      50      51      