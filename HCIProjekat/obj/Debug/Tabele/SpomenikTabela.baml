   M S B A M L   `   `   `  ����F  BHCIProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HCIProjekat.TabeleHCIProjekat.Tabele  5   	   '    !HCIProjekat.Tabele.SpomenikTabela   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HCIProjekat.Tabele     5   	     � Icon$  /Images/earthlogo.png��5   	    � Title$ SpomeniciTabela��5	   	   $	��450��6!   $	��850��6.    � WindowStartupLocation$ CenterScreen=�6:   .��5
      � $��Stretch=�6   $��Stretch=�6*   
���OO/�.+�5   
   �� $��
0,0,-0.4,0q�6   .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��
Pretraži:��6    � ToolTip$$ Pretrazi po oznakama ili imenu��6,   $��0,11,18.6,-11.4q�6U   �� 5      -   5        $��pretrazibox��5      $" Pretrazi po oznaci ili imenu��6.   $��4��6U   $��100,10,90.4,-11.4q�6i   6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgrMain��5      $��	0,44,0,35q�6"      
IsReadOnly .    AutoGenerateColumns .  
���������65   ��  �� Path$
 Spom�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 3* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5       $		 Ime��6%   $
 3* 6J    62   �� *Ime+6J     5!      $	 Klima��6%   $
 3* 6N    64   �� *Klima+6N     5"      $	 Status��6%   $
 3* 6Z    65   �� *TuristickiStatus+6Z   4  .System.Windows.Controls.DataGridCheckBoxColumn  5#      $	 Naseljen reg.��6)   $
 3* 6c    6@   �� *NaseljenRegion+6c     5$      $	 Ugr. zivotinja��6)   $
 3* 6h    6A   �� *UgrozenihZivotinja+6h     5%      $	 Ekoloski ugr.��6)   $
 3* 6g    6@   �� *EkoloskaUgrozenost+6g     5&      $	 Prihod��6%   $
 3* 6P    65   �� *Prihod+6P     5'      $		 Tip��6%   $
 3* 6N    62   �� *	Tip.Ime+6N   4  .System.Windows.Controls.DataGridTemplateColumn  5(      $	 Ikonica��6)      CellTemplate 5)      �� 5*      .R�5+      �� $��20��6F   $��20��6R   ��6$   �� *IkonicaPutanja+6R   5,      5.        5/      $	 Datum otkrivanja��6%    6?   �� *DatumOtkrivanja+   RowDetailsTemplate 51      �� 52      .R�53      ]� 
����ح�.+�54      �� $
��Left=�6    $��80��66   ��6C   �� $ IkonicaPutanja�� 55      $	��5,5q�6    56      �� 57   "   $
��Auto �63   �� 58   "   $��* �63    � RowDefinitions 5:      �� 5;   "   $
��Auto �60   �� 5<   "   $
��Auto �60   �� 5=   "   $
��Auto �60   .+�5@      �� $��Opis:��6(   $��0��66   $��0��6F   $��Black"�6S   $	��5,5q�6f   �� 5A      $��Tip spomenika:��6(   $��0��6?   $��1��6O   $��Black"�6\   $	��5,5q�6o   �� 5B      $��Etikete:��6(   $��0��69   $��2��6I   $��Black"�6V   $	��5,5q�6i   �� 5D      $��1��6D   $��0��6T   $	��5,5q�6a   ��6(   �� $
 Opis�6a   �� 5E      $��1��6C   $��1��6S   $	��5,5q�6`   ��6(   �� $	 Tip�6`   �� 5F      $��1��6J   $��2��6Z   $	��200��6g   $��60��6s   $
��Left=�6   ��6&   �� *
TagEtikete+��5G   "   �� 5H   &   .R�5I   *   �� ��64   �� $ Id�5K   +   5L   '   5N      5O      5P      5Q      5S      �� 5T   
   -   5        $��Obrisi��5T      $��Right=�6"   $��0,0,20,6q�6>   $��Bottom=�6P   $��69��6k   $��21��6v   6�   �� 5U   
   -   5        $��Izmeni��5U      $��Right=�6"   $��0,0,96,6q�6>   $��Bottom=�6P   $��69��6k   $��21��6v   6�   5W      5X      