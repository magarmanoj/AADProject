   M S B A M L   `   `   `  ����M  IAAD.ImmoWin.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AAD.ImmoWin.WpfApp.ViewsAAD.ImmoWin.WpfApp.Views  5   	   *    $AAD.ImmoWin.WpfApp.Views.HuisAddView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:AAD.ImmoWin.WpfApp.Views     5   	   {�5   2   �� *	IsEnabled+.��5	      �   � RowDefinitions  5
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
   $��5q�6f   $��2��6q   ��6   �� *FilteredHuizen+ �� SelectedItem 69   �� *GeselecteerdeHuizen+6�   �� 5   
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
��auto �6'   .+�5-      �� $��0��6   $��5q�6n   $��2��6y   ��6(   �� *	Klanten+ 6H   �� *SelectedType+6�   �� 5.      $��Types��6   $��Center=�6(   $��5q�6C   $��1��6N   6]   �� 5/      $��Waarde��6   $��Center=�6)   $��5q�6D   $��2��6O   6^   �� 50      $��Straat��6   $��Center=�6)   $��5q�6D   $��3��6O   6^   �� 51      $��Nummer��6   $��Center=�6)   $��5q�6D   $��4��6O   6^   �� 52      $��
Postnummer��6   $��Center=�6-   $��5q�6H   $��5��6S   6b   �� 53      $��Gemeente��6   $��Center=�6+   $��5q�6F   $��6��6Q   6`   �� 54      $��	BouwDatum��6   $��Center=�6,   $��5q�6G   $��7��6R   6a   �� 56      $��Center=�6:   $��1��6U   $��5q�6b   $��1��6m   ��6   �� *NewHuizen.Type+6m   �� 57      $��Center=�6<   $��2��6W   $��5q�6d   $��1��6o   ��6   �� *NewHuizen.Waarde+6o   �� 58      $��Center=�6B   $��3��6]   $��5q�6j   $��1��6u   ��6   �� *NewHuizen.Adres.Straat+6u   �� 59      $��Center=�6B   $��4��6]   $��5q�6j   $��1��6u   ��6   �� *NewHuizen.Adres.Nummer+6u   �� 5:      $��Center=�6F   $��5��6a   $��5q�6n   $��1��6y   ��6   �� *NewHuizen.Adres.Postnummer+6y   �� 5;      $��Center=�6D   $��6��6_   $��5q�6l   $��1��6w   ��6   �� *NewHuizen.Adres.Gemeente+6w   (  "System.Windows.Controls.DatePicker  5<      $��Center=�6J   $��7��6e   $��5q�6r   $��1��6}      SelectedDate 6   �� *NewHuizen.BouwDatum+6}   5=      5>      A� 5A   
    A� Columns$ 4��6   $��5q�6"   $��4��6-   .+�5B      �� $��	Toevoegen��6   $��5q�6R   ��6)   �� *HuisToevoegenCommand+6_   �� 5C      $��Wijzigen��6   $��5q�6P   ��6(   �� *HuisWijzigenCommand+6]   �� 5D      $��Verwijderen��6   $��5q�6V   ��6+   �� *HuisVerwijderenCommand+6c   5E      �� 5F   
   $��5��6   6   5H      5I      