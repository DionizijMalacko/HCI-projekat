   M S B A M L   `   `   `  ����F  BHCIProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HCIProjekat.TabeleHCIProjekat.Tabele  5   	   "    HCIProjekat.Tabele.TipTabela   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HCIProjekat.Tabele     5   	     � Title$  	TipTabela��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      � $��Stretch=�6   $��Stretch=�6'   
���OO/�.+�5
   
   �� $��
Pretraži:��6    � ToolTip$' !Pretrazite po oznakama i nazivima��6%   $��10,10,307,0q�6Q   $��28��6f   $	��Top=�6r   �� 5   
   -   5        $��	searchBox��5   9   $! Pretraga tipova po oznakama��6   $��150,10,9.6,0q�6J   $��28��6a   $	��Top=�6m   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgrMain��5         
IsReadOnly .    AutoGenerateColumns .  $��0,43,-0.4,32q�6r   
���������6R   ��  �� Path$ Tp�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 3* 6H   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+6H     5      $	 Ime��6%   $	 3* 6J   
 62   �� *Ime+6J     5      $
 Opis��6%   $	 3* 6L   
 63   �� *Opis+6L   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Ikonica��6)   $	 3* 6:      CellTemplate 5      �� 5      .R�5      �� $��20��6F   $��20��6R   ��6$   �� *IkonicaPutanja+6R   5      5         RowDetailsTemplate 5      �� 5      .R�5      ]� 
�������.+�5      �� $��Bottom=�6    $��80��68   ��6D   �� $ IkonicaPutanja�� 5      $	��5,5q�6    � ColumnDefinitions 5       �� 5!   "   $
��Auto �63   �� 5"   "   $��* �63    � RowDefinitions 5$      �� 5%   "   $
��Auto �60   5(      5)      5+      5.      �� 5/   
   -   5        $��Obrisi��5/      $��Right=�6"   $��0,0,20,6q�6>   $��Bottom=�6P   $��69��6k   $��21��6v   
�������6�   �� 50   
   -   5        $��Izmeni��50      $��Right=�6"   $��0,0,96,6q�6>   $��Bottom=�6P   $��69��6k   $��21��6v   
�������6�   52      53      