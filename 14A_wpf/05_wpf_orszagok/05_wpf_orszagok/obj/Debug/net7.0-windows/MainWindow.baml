   M S B A M L   `   `   `  ����J  F05_wpf_orszagok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:_05_wpf_orszagok_05_wpf_orszagok  5   	   !    _05_wpf_orszagok.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:_05_wpf_orszagok     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $��16(�5	   	   $	��380��5
   	   $	��700��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��
Országok:��6   $��5q�6%   $
��Bold"�60   �� 5   
   $	��300��6   $��5q�6   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5      ��5      �� ��5      �� 5      .R�5      �� $��1q�6   
��� � �$	��300��5        �� Padding$ 5q�5!       �� CornerRadius$ 5��5"      ._�5#      ��  �� Orientation$ 
Horizontal=�6%   .+�5$      �� $��5q�5%   $   $��50��5&   $   ��5$   $   �� *zaszlo+5&   $   �� 5'      .+�5(   "   �� ��6(   �� *
megnevezes+�� 5)   "   $
��Bold"�6A   ��6(   �� *kod2+6A   5*      5+      5,      5.      50      �� 53   
   $��1��6   .+�54      �� $��Adatok:��6   $
��Bold"�6'   $��5q�69   �� 55      ��6   �� *
megnevezes+ �� StringFormat$ Megnevezés: {0}���� 56      ��6   �� *kod2+57      58      59      