   M S B A M L   `   `   `  ����M  IAAD.ImmoWin.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AAD.ImmoWin.WpfApp.ViewsAAD.ImmoWin.WpfApp.Views  5      +    %AAD.ImmoWin.WpfApp.Views.HuisDataView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:AAD.ImmoWin.WpfApp.Views     5      .��5	      � .+�5
   
   �   � RowDefinitions  5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �� $��Types:��6   $
��Left=�6%   $��Center=�6@   $��5q�6[   $��0��6f   6u   �� 5      $��Waarde:��6   $
��Left=�6&   $��Center=�6A   $��5q�6\   $��1��6g   6v   �� 5      $��Straat:��6   $
��Left=�6&   $��Center=�6A   $��5q�6\   $��2��6g   6v   �� 5      $��Nummer:��6   $
��Left=�6&   $��Center=�6A   $��5q�6\   $��3��6g   6v   �� 5      $��Postnummer:��6   $
��Left=�6*   $��Center=�6E   $��5q�6`   $��4��6k   6z   �� 5      $��	Gemeente:��6   $
��Left=�6(   $��Center=�6C   $��5q�6^   $��5��6i   6x   �� 5       $��	Gemeente:��6   $
��Left=�6(   $��Center=�6C   $��5q�6^   $��6��6i   6x   �� 5"      $��EigenaarVoornaam:��6   $
��Left=�60   $��Center=�6K   $��5q�6f   $��7��6q   6�   �� 5#      $��EigenaarFamilienaam:��6   $
��Left=�63   $��Center=�6N   $��5q�6i   $��8��6t   6�   �� 5$      $��Center=�6X   $��5q�6s   $��1��6~   $��0��6�   ��6   �� *Huizen.Type+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5%      $��Center=�6Z   $��5q�6u   $��1��6�   $��1��6�   ��6   �� *Huizen.Waarde+$ PropertyChanged=�6�   �� 5&      $��Center=�6`   $��5q�6{   $��1��6�   $��2��6�   ��6   �� *Huizen.Adres.Straat+$ PropertyChanged=�6�   �� 5'      $��Center=�6`   $��5q�6{   $��1��6�   $��3��6�   ��6   �� *Huizen.Adres.Nummer+$ PropertyChanged=�6�   �� 5(      $��Center=�6d   $��5q�6   $��1��6�   $��4��6�   ��6   �� *Huizen.Adres.Postnummer+$ PropertyChanged=�6�   �� 5)      $��Center=�6b   $��5q�6}   $��1��6�   $��5��6�   ��6   �� *Huizen.Adres.Gemeente+$ PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  5*      $��Center=�6D   $��6��6_   $��5q�6l   $��1��6w      SelectedDate 6   �� *Huizen.BouwDatum+6w   �� 5+      $��1��6   $��7��6)    �� Orientation$ 
Horizontal=�66   $��5q�6O   .+�5,      �� $��Center=�6f   $��5q�6�   $	��100��6�    �� 
IsReadOnly . ��6   �� *Huizen.Klant.Voornaam+$ PropertyChanged=�6�   �� 5-      $��5q�6a   $	��100��6l   ��6   �� *	Klanten+ �� SelectedItem 6;   �� *SelectedType+6l   5.      �� 5/      $��Center=�6e   $��5q�6�   $��1��6�   $��8��6�   ��6   �� *Huizen.Klant.Familienaam+$ PropertyChanged=�6�   50      51      52      