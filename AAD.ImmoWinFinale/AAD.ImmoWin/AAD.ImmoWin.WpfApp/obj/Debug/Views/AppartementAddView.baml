   M S B A M L   `   `   `  ����M  IAAD.ImmoWin.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AAD.ImmoWin.WpfApp.ViewsAAD.ImmoWin.WpfApp.Views  5   	   1    +AAD.ImmoWin.WpfApp.Views.AppartementAddView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:AAD.ImmoWin.WpfApp.Views     5   	   {�5   2   �� *	IsEnabled+.��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $	��150 �6   6+   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   ��    
TitelLabel#��[  6*   ��6   �� *Title+6P   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��5q�6;   .+�5      �� $��Zoek op:��6   $��Center=�6'   {�.  6B   �� 5      $	��200��6W   $��Center=�6c    �� TextAlignment$
 Left=�6~   ��6   �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=�6~   �� 5      $��Sorteer op prijs��6   $��5q�6W   ��60   �� *SortByPriceCommand+6W   �� 5      $��
Vernieuwen��6   $��5q�6U   ��6*   �� *LijstVernieuwenCommand+6b   5      �� 5   
   $��5q�6p   $��2��6{   ��6   �� *FilteredAppartement+ �� SelectedItem 6>   �� *GeselecteerdeAppartement+6�   �� 5   
   $��3��6   $
��Auto=�6$   .��5      �   5      �� 5      $
��auto �6$   64   �� 5       $
��auto �6$   65   �� 5!      $
��auto �6$   65   �� 5"      $
��auto �6$   65   �� 5#      $
��auto �6$   65   �� 5$      $
��auto �6$   65   �� 5%      $
��auto �6$   65   �� 5&      $
��auto �6$   65    � ColumnDefinitions 5(      �� 5)      $	��100 �6'   �� 5*      $	��250 �6'   �� 5+      $
��auto �6'   .+�5-      �� $��0��6   $��5q�6o   $��2��6z   ��6)   �� *	Klanten+ 6I   �� *SelectedType+6�   �� 5.      $��
Verdieping��6   $
��Left=�6-   $��Center=�6H   $��5q�6c   $��1��6n   6}   �� 5/      $��Waarde��6   $
��Left=�6)   $��Center=�6D   $��5q�6_   $��2��6j   6y   �� 50      $��Straat��6   $
��Left=�6)   $��Center=�6D   $��5q�6_   $��3��6j   6y   �� 51      $��Nummer��6   $
��Left=�6)   $��Center=�6D   $��5q�6_   $��4��6j   6y   �� 52      $��
Postnummer��6   $
��Left=�6-   $��Center=�6H   $��5q�6c   $��5��6n   6}   �� 53      $��Gemeente��6   $
��Left=�6+   $��Center=�6F   $��5q�6a   $��6��6l   6{   �� 54      $��	BouwDatum��6   $
��Left=�6,   $��Center=�6G   $��5q�6b   $��7��6m   6|   �� 55      $��Center=�6F   $��1��6a   $��5q�6n   $��1��6y   ��6   �� *NewAppartement.Verdieping+6y   �� 56      $��Center=�6B   $��5q�6]   $��2��6h   $��1��6u   ��6   �� *NewAppartement.Waarde+6u   �� 57      $��Center=�6H   $��3��6c   $��5q�6p   $��1��6{   ��6   �� *NewAppartement.Adres.Straat+6{   �� 58      $��Center=�6H   $��4��6c   $��5q�6p   $��1��6{   ��6   �� *NewAppartement.Adres.Nummer+6{   �� 59      $��Center=�6L   $��5��6g   $��5q�6t   $��1��6   ��6   �� *!NewAppartement.Adres.Postnummer+6   �� 5:      $��Center=�6J   $��6��6e   $��5q�6r   $��1��6}   ��6   �� *NewAppartement.Adres.Gemeente+6}   (  "System.Windows.Controls.DatePicker  5;      $��Center=�6P   $��7��6k   $��5q�6x   $��1��6�      SelectedDate 6   �� *NewAppartement.BouwDatum+6�   5<      5=      A� 5@   
    A� Columns$ 4��6   $��5q�6"   $��4��6-   .+�5A      �� $��	Toevoegen��6   $��5q�6Y   ��6)   �� *AppartementToevoegenCommand+6f   �� 5B      $��Wijzigen��6   $��5q�6W   ��6(   �� *AppartementWijzigenCommand+6d   �� 5C      $��Verwijderen��6   $��5q�6]   ��6+   �� *AppartementVerwijderenCommand+6j   5D      �� 5E   
   $��5��6   6   5G      5H      