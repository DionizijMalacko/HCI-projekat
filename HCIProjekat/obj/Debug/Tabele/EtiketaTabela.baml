   M S B A M L   `   `   `  ����F  BHCIProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HCIProjekat.TabeleHCIProjekat.Tabele  5   	   &     HCIProjekat.Tabele.EtiketaTabela   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HCIProjekat.Tabele     5   	     � Title$  EtiketeTabela��5   	   $	��450��6   $	��500��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]   .��5
      � 
���OO/� � ColumnDefinitions 5   
   �� 5      $
��245* �6   �� 5      $
��149* �6   .+�5   
   �� $��Pretraži :��6    � ToolTip$  Pretraga po oznaci etikete��6%   $��10,10,164.2,0q�6J   $��28��6a   $	��Top=�6m   �� 5   
   -   5        $��	searchBox��5      $��
148,10,9,0q�6$   $��28��68   $	��Top=�6D   $��2��6\   6p   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgrMain��5         
IsReadOnly .    AutoGenerateColumns .  $��0,43,-0.4,35q�6t   
�������$��2��6�   ��6R   ��  �� Path$
 Etik�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $

 Boja��6%   $ 3* 63      ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value 5      �� *Boja+ )  %ColorToSolidColorBrush_ValueConverter �� 	Converter# [  5      5         RowDetailsTemplate 5"      �� 5$      .R�5%      ]� 
�������.+�5'      � $	��5,5q�6    5(      �� 5)   "   $
��Auto �63   �� 5*   "   $��* �63    � RowDefinitions 5,      �� 5-   "   $
��Auto �60   .+�50      �� $��Opis:��6(   $��0��66   $��0��6F   $	��5,5q�6T   �� 52      $��1��6D   $��0��6T   $	��5,5q�6a   ��6(   �� $
 Opis�6a   53      54      55      57      �� 58   
   -   5        $��	ObrisiBtn��58      $��307,0,117.6,6q�6%   $��Bottom=�6<   $��69��6W   $��21��6b   
�������$��2��6�   �� 59   
   -   5        $��	IzmeniBtn��59      $��183,0,55.2,6q�6%   $��Bottom=�6;   $��69��6V   $��21��6a   
�������6�   5;      5<      