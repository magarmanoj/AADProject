   M S B A M L   `   `   `  ����M  IAAD.ImmoWin.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AAD.ImmoWin.WpfApp.ViewsAAD.ImmoWin.WpfApp.Views  5      .    (AAD.ImmoWin.WpfApp.Views.KlantDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:AAD.ImmoWin.WpfApp.Views     5      {�5	      �� *	IsEnabled+.��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      6!   .+�5   
   �� $��
Voornaam: ��6   $��Right=�6%   $��Center=�6A   $��3q�6\   $��0��6g   $��0��6t   6�   �� 5   
   $��Familienaam: ��6   $��Right=�6(   $��Center=�6D   $��3q�6_   $��1��6j   $��0��6w   6�   �� 5   
   $��Center=�6W   $��3q�6r   $��0��6}   $��1��6�   ��6   �� *Klant.Voornaam+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Center=�6Z   $��3q�6u   $��1��6�   $��1��6�   ��6   �� *Klant.Familienaam+$ PropertyChanged=�6�   5      5      