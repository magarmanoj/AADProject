   M S B A M L   `   `   `  ����M  IAAD.ImmoWin.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AAD.ImmoWin.WpfApp.ViewsAAD.ImmoWin.WpfApp.Views  5      2    ,AAD.ImmoWin.WpfApp.Views.AppartementDataView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:AAD.ImmoWin.WpfApp.Views     5      {�5	      �� *	IsEnabled+.��5      � .+�5   
   �   � RowDefinitions  5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5      $	��100 �6#   �� 5      $��* �6#   .+�5      �� $��Verdieping:��6   $
��Left=�6*   $��Center=�6E   $��5q�6`   $��0��6k   �� 5      $��Waarde:��6   $
��Left=�6&   $��Center=�6A   $��5q�6\   $��1��6g   �� 5      $��Straat:��6   $
��Left=�6&   $��Center=�6A   $��5q�6\   $��2��6g   �� 5      $��Nummer:��6   $
��Left=�6&   $��Center=�6A   $��5q�6\   $��3��6g   �� 5       $��Postnummer:��6   $
��Left=�6*   $��Center=�6E   $��5q�6`   $��4��6k   �� 5!      $��	Gemeente:��6   $
��Left=�6(   $��Center=�6C   $��5q�6^   $��5��6i   �� 5"      $��
BouwDatum:��6   $
��Left=�6)   $��Center=�6D   $��5q�6_   $��6��6j   �� 5#      $��EigenaarVoornaam:��6   $
��Left=�60   $��Center=�6K   $��5q�6f   $��7��6q   �� 5$      $��EigenaarFamilienaam:��6   $
��Left=�63   $��Center=�6N   $��5q�6i   $��8��6t   �� 5&      $��Center=�6c   $��5q�6~   $��1��6�   ��6   �� *Appartement.Verdieping+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5'      $��Center=�6_   $��5q�6z   $��1��6�   $��1��6�   ��6   �� *Appartement.Waarde+$ PropertyChanged=�6�   �� 5(      $��Center=�6e   $��5q�6�   $��1��6�   $��2��6�   ��6   �� *Appartement.Adres.Straat+$ PropertyChanged=�6�   �� 5)      $��Center=�6e   $��5q�6�   $��1��6�   $��3��6�   ��6   �� *Appartement.Adres.Nummer+$ PropertyChanged=�6�   �� 5*      $��Center=�6i   $��5q�6�   $��1��6�   $��4��6�   ��6   �� *Appartement.Adres.Postnummer+$ PropertyChanged=�6�   �� 5+      $��Center=�6g   $��5q�6�   $��1��6�   $��5��6�   ��6   �� *Appartement.Adres.Gemeente+$ PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  5,      $��Center=�6H   $��5q�6c   $��1��6n   $��6��6~      SelectedDate 6   �� *Appartement.BouwDatum+6~   �� 5-      $��1��6   $��7��6)    �� Orientation$ 
Horizontal=�66   $��5q�6O   .+�5.      �� $��Center=�6k   $��5q�6�   $	��100��6�    �� 
IsReadOnly . {�.  ��6   �� *Appartement.Klant.Voornaam+$ PropertyChanged=�6�   �� 5/      $��5q�6a   $��80��6l   ��6   �� *	Klanten+ �� SelectedItem 6;   �� *SelectedType+6l   50      �� 51      $��Center=�6j   $��5q�6�   $��1��6�   $��8��6�    . {�.  ��6   �� *Appartement.Klant.Familienaam+$ PropertyChanged=�6�   52      53      54      