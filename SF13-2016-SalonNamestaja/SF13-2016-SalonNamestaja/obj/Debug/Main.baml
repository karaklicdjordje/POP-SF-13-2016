   M S B A M L   `   `   `  ����S  OSF13-2016-SalonNamestaja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SF13_2016_SalonNamestajaSF13_2016_SalonNamestaja  5   	   #    SF13_2016_SalonNamestaja.Main   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:SF13_2016_SalonNamestaja     5   	     � Title$  Salon namestaja��5   	   $��413.013��6!   $��758.219��62    � WindowStartupLocation$ CenterScreen=�6B   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $
��Left=�6%   $	��251��6@   $��	21,68,0,0q�6M   $	��Top=�6`   $	��709��6x   �� 5   
   $��Odabir prikaza:��6   $
��Left=�6*   $��	50,22,0,0q�6E   $	��Top=�6X   �� 5   
   -   5         ��Name$ comboPrikazTabela��5      $
��Left=�6.   $��
142,26,0,0q�6I   $	��Top=�6]   $	��120��6u    J� RenderTransformOrigin$ -0.05,0.864&�6�    �� SelectedIndex$ 0��6�   6�   �� 5   
   -   5         ��Name$ btUpis��5      $
��Upis��6!   $
��Left=�60   $��220,337,0,0q�6K   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $ btIzmena��5      $��Izmena��6#   $
��Left=�64   $��322,337,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ 
btBrisanje��5      $��Brisanje��6%   $
��Left=�68   $��424,337,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $ buttonUpisProdaje��5      $��Upis prodaje��6,   $
��Left=�6C   $��
21,337,0,0q�6^   $	��Top=�6r   $��84��6�   6�   �� 5   
   $��	Pretraga:��6   $
��Left=�6$   $��
295,26,0,0q�6?   $	��Top=�6S   �� 5   
   -   5         ��Name$ txtPretraga��5      $
��Left=�6'   $��23��6B   $��
357,29,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��119��6�   �� 5   
   -   5        $ 
btPretrazi��5      $��Pretrazi��6%   $
��Left=�68   $��
499,29,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -	   5        $ btPrikaziSve��5      $��Prikazi sve��6'   $
��Left=�6=   $��
604,29,0,0q�6X   $	��Top=�6l   $��74��6�   6�   5      5      