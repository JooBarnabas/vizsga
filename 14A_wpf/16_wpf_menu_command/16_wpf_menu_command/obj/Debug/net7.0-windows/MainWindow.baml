   M S B A M L   `   `   `  ����N  J16_wpf_menu_command, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:_16_wpf_menu_command_16_wpf_menu_command  5   	   %    _16_wpf_menu_command.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:_16_wpf_menu_command     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$
 Open��5
      CMD_open��5        5   
   -   5        $
 Save��5      CMD_save��5        5   
   -   5        )   #_16_wpf_menu_command.SajatParancsok   Exit# Z 5      CMD_kilepes��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   o� .@�5       m� $��_Fájl��6   .@�5!      m� $��
Megnyitás��6    m� Command$
 Open��6.    m� Icon 5"      �� 5#      $��menuicon/folder.png��6    5%      m� 5&      $��Mentés��6   $
 Save��6+    5'      �� 5(      $��menuicon/save.png��6    5*      m� 5+      $��	Kilépés��6   # Z 6,    5,      �� 5-      $��menuicon/exit.png��6    5/      50      m� 51      $��For_mázás��6   .@�52      m� $��Félkövér��6    m� IsCheckable$
 True��53      54      55      c� 58   
   $��1��6   $��30��6   .@�59      �� $
��Open��6   .��5:      ��  �� Orientation$ 
Horizontal=�6   .+�5;      �� $��menuicon/folder.png��6   �� 5<      $��
Megnyitás��6    5=      5>      �� 5?      $
��Save��6   .��5@      �� $ 
Horizontal=�6   .+�5A      �� $��menuicon/save.png��6   �� 5B      $��Mentés��6    5C      5D      �� 5E      #��Z 6   .��5F      �� $ 
Horizontal=�6   .+�5G      �� $��menuicon/exit.png��6   �� 5H      $��	Kilépés��6    5I      5J      5K      �� 5N   
   -   5        	 ��Name$	 	TB_szoveg��5N      $��2��6%   
 �� TextWrapping$

 Wrap=�5O       �� AcceptsReturn$
 True��5P      5R      5S      