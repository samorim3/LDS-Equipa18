#  Sistema de Reservas de Espaços

Este projeto consiste numa aplicação desenvolvida em **C# com Windows Forms**, baseada no padrão **MVC (Model-View-Controller)**, que permite gerir reservas de espaços como salas de estudo, laboratórios e auditórios.

---

##  Estrutura do Projeto

- **Model**
  - Representa a lógica de negócio e os dados (reservas, espaços, utilizadores).
  
- **View** → Interface gráfica com o utilizador (WinForms)
  - Permite ao utilizador introduzir dados e visualizar mensagens.
  - Ficheiros principais: `Form1.cs`, `Form1.Designer.cs`

- **Controller** → Lógica intermédia entre View e Model
  - Gere a interação e coordena chamadas entre View e Model.
  - Ficheiro: `Controller.cs`

- **Program.cs** → Ponto de entrada da aplicação

---

## 🖥 Funcionalidades atuais

 Interface gráfica simples com:
- Campo para introduzir o nome do utilizador  
- Campo para o nome do espaço a reservar  
- Seleção de data e hora  
- Botões para ver espaços disponíveis e criar reserva

 Mensagens de feedback com caixas de diálogo (`MessageBox`)

 **A lógica de reserva ainda é simulada.** Assim que o Model estiver implementado, o Controller será atualizado para usar métodos reais de verificação e armazenamento.

---

##  Tecnologias usadas

-  C# (.NET 8)
-  Windows Forms
-  Padrão arquitetónico MVC

---

## Como correr o projeto

### Requisitos:
- .NET 8 SDK (ou superior)
- Visual Studio ou Visual Studio Code com extensões C# instaladas
