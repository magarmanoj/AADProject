   M S B A M L   `   `   `  ����M  IAAD.ImmoWin.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AAD.ImmoWin.WpfApp.ViewsAAD.ImmoWin.WpfApp.Views  5      /    )AAD.ImmoWin.WpfApp.Views.KlantenLijstView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:AAD.ImmoWin.WpfApp.Views     5      {�5	      �� *	IsEnabled+.��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   ��    
TitelLabel#��[  6*   ��6   �� *Title+6P   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��5q�6;   .+�5      �� $��Zoek klanten op:��6   $��Center=�6/   {�.  6J   �� 5      $	��200��6W   $��Center=�6c   ��6   �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=�6c   5      �� 5   
   $��5q�6f   $��2��6q   ��6   �� *FilteredKlanten+ �� SelectedItem 6:   �� *GeselecteerdeKlant+6�   A� 5   
    A� Columns$ 4��6   $��5q�6"   $��4��6-   .+�5      �� $��	Toevoegen��6   $��5q�6S   ��6)   �� *KlantToevoegenCommand+6`   �� 5      $��Wijzigen��6   $��5q�6Q   ��6(   �� *KlantWijzigenCommand+6^   �� 5      $��Verwijderen��6   $��5q�6W   ��6+   �� *KlantVerwijderenCommand+6d   5      �� 5    
   $��3��6   $ Vertical=�6"   $��5q�69   .+�5!      �� $��Voornaam��6   6)   �� 5"      -   5         ��Name$ txtVoornaam��5"      $��5q�6u   ��6+   �� *NewKlanten.Voornaam+$ PropertyChanged=�6u   �� 5#      $��Familienaam��6   6,   �� 5$      -   5        $ txtFamilienaam��5$      $��5q�6{   ��6.   �� *NewKlanten.Familienaam+$ PropertyChanged=�6{   5%      �� 5&   
   $��5��6   6   5(      5)      