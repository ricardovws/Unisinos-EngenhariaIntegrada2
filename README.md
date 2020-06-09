# Unisinos - Engenharia Integrada 2
Projeto da disciplina de Engenharia Integrada II: Automação e Robótica, do curso de Engenharia Mecânica da Universidade do Vale dos Sinos.

 A proposta da disciplina é desenvolver uma solução envolvendo automação, aplicando os conhecimentos adquiridos até o momento no curso de engenharia mecânica. A solução proposta é uma estufa automatizada de cultivo indoor de hortaliças. Neste diretório, estarão contidos apenas a parte do projeto relativo aos softwares e ao hardware. As demais outras partes, como:
 
* #### Projeto térmico 
* #### Projeto de irrigação

 Não estarão contidos aqui.
 
 ## Como funciona?
 
 Abaixo está uma imagem mostrando o funcionamento básico do sistema de controle da estufa:
 
 ![](imagens/sistema_basico.png)
 
 ## Arduino Uno.
 O Arduino será responsável por hospedar todos os sensores e componentes de acionamento dos sistemas de irrigação, iluminação, ventilação e exaustão. Além disso, o seu microprocessador irá executar um programa que coleta os dados dos sensores e os envia para uma porta de comunicação serial. Através desta mesma porta serial, o programa também insere dados de entrada, fazendo com que os sistemas já citados, sejam acionados de forma individual. Como o Arduino dispõe de um cabo USB para comunicação por hardware, esse cabo é conectado em um computador, fazendo a comunicação entre ambos. Abaixo está o desenho do projeto de hardware do Arduino:
 
 ![](imagens/arduino_hardware.png)
 
 O programa desenvolvido no Arduino, está disponível [aqui](https://github.com/ricardovws/Unisinos-EngenhariaIntegrada2/blob/master/CodigoArduino/CodigoArduino.ino).
 
 ## Software de Serviço (ColetorArduino).
 DIvagações.

## Sistema web para controle total (EngInt2).
 DIvagações.
