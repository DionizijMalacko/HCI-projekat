   M S B A M L   `   `   `  ����F  BHCIProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HCIProjekatHCIProjekat  5   	   9!clr-namespace:HCIProjekat.KomandeHCIProjekat.Komande  5   	   7 clr-namespace:HCIProjekat.ModeliHCIProjekat.Modeli  5   	       HCIProjekat.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HCIProjekat     5   	   1cmd!clr-namespace:HCIProjekat.Komande     5   	   1mods clr-namespace:HCIProjekat.Modeli     5   	     � Title$  Spomenici kulture��5
   	   $��542.8��6#   $��886.8��62   $��20(�6@    � WindowStartupLocation$ CenterScreen=�6N    � 	Resources 5         
FolderOpen �� 	UriSource  FolderClosed  	SmallIcon �� 
TargetType �� Property �� Value��%  &	        &	 8     &	 o     �� 5   
   $$ HCIProjekat/Images/foldero.png?�6)   �� 5   
   $# HCIProjekat/Images/folder.png?�6+   �� 5   
   " ��6"   .�5      ��  � ��$ 20��6)   �� 5       � ��$ 20��6*   �� 5       � ��$ 1q�6'   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        (   "HCIProjekat.Komande.RoutedCommands   FormaSpomenik	   Command#	 Z 5      6O     5   
   -   5        
   FormaTip#	 Z
 5      6J     5   
   -   5           FormaEtiketa#	 Z 5      6N     5   
   -   5           TabelaSpomenici#	 Z 5      6Q     5   
   -   5           TabelaEtikete#	 Z 5      6O     5   
   -   5           TabelaTipovi#	 Z 5      6N   .��5"      ]� .+�5#   
   ]� $��Bottom=�6   
���OO/�.+�5$      �� $��Bottom=�6   $��Status bar:��6,   $��13(�6B   $��25��6P   6^   5%      ]� 5&   
   .+�5'      o� $	��Top=�6   
���������5(      �� 5)      .R�5*      ]� $
��Left=�6$   6A   5+      .@�5.      m� $��_Dodaj��6   .@�5/      m� $��_Novi Spomenik��6    m� Command# Z 67   6p   m� 50      $��	_Novi Tip��6   # Z
 62   6f   m� 51      $��_Novu Etiketu��6   # Z 67   6p   52      m� 54      $��_Pregled��6   .@�55      m� $��	Spomenika��6   # Z 63   m� 56      $��Tipova��6   # Z 6/   m� 57      $��Etiketa��6   # Z 61   58      m� 5:      $��_Pomoć��6   .@�5;      m� -   5        $��
O projektu��5;      63   m� 5<      -   5        $��Pomoc��5<      6.   5=      m� 5L      $��_Ukloni��6   .@�5M      m� -	   5        $��Ukloni sa mape��5M      67   5N      5Q      � 5R      $��Bottom=�6   $��Stretch=�6+   $��Stretch=�6G   .+�5S      ]� .+�5T      � $
��Left=�6   $	��200��61   
������� � ColumnDefinitions 5U      �� 5V      $
��131* �6/   �� 5W      $	��69* �6/   .+�5Y      R� -
   5        $��treeSpomenici��5Y   #    � ToolTip$( "Prevucite zeljeni spomenik na mapu��6W   $��5,5,5,5q�6�   $��Stretch=�6�   $��Stretch=�6�   $��2��6+  ��68   �� *Tipovi+ 5Z       �� DataType   HCIProjekat.Modeli.Tip �� ItemsSource �� Orientation �� BasedOn � ContextMenu!   HCIProjekat.Modeli.Spomenik��%�  (��       5[   ;   *, +)7  (�� �    5l   /   *, +)7  �� 5[   "   "  6;    6X   �� *TipSpomenici+.R�5\   &   �� $ 
Horizontal=�61   .+�5]   *   �� $��0,0,5,0q�60   ��5^   .   �� 5_   2   8   " ��6i   .�5`   6   ��  � �� 6O   �� *IkonicaPutanja+5a   3   5c   +   �� 5d   *   ��64   �� *Id+ 5e   *   �� 5f   .   .@�5g   2   m� $��Dodaj��6;    6J   �� *Add+6d   5h   /   5j   '   5k   #   �� 5l   "   "  6/   .R�5m   &   �� $ 
Horizontal=�61   .+�5n   *   �� $��0,0,5,0q�60   ��5o   .   �� 5p   2   8   " ��6i   .�5q   6   ��  � �� 6O   �� *IkonicaPutanja+5r   3   5t   +   �� 5u   *   ��64   �� *Id+5v   '   5w   #   5x      5y      5z      � 5|      $��Right=�6   
�������.+�5}      �� -   5         ��Name$ 	MapaSveta��5}   !   $��12,12,12,12q�64    J� 	AllowDrop . ��5~      �� 5   "    �� ImageSource$ Images/mapaSveta1.jpg��6-   6S   5�      5�      5�      5�      5�      5�      5�      