# 💼 Sistema de Vendas - Projeto Acadêmico (2º BIM - Programação III)

Este repositório contém um sistema de vendas desenvolvido como projeto acadêmico para a disciplina de Programação III. O sistema foi construído com base nos princípios de **Programação Orientada a Objetos** e segue a arquitetura **MVC (Model-View-Controller)** com interface gráfica **Windows Forms (WinForms)** em C#.

## 🧾 Funcionalidades

- 🧍 Cadastro e gerenciamento de **clientes**
- 📦 Cadastro e controle de **produtos** e **estoque**
- 💰 Registro e visualização de **vendas**
- 👤 Gestão de **usuários**, com controle de acesso por nível (admin/comum)
- 📈 Geração de **gráficos** com dados do banco
- 📑 Exportação de dados em **PDF**
- 🧠 Importação de dados via **CSV**
- 💽 Recurso de **backup e restauração** do banco de dados
- 📄 Geração de **arquivo de log** com ações (inserções, exclusões, logins)
- 🖥️ Navegação via **MDI (Multiple Document Interface)**
- 📊 Uso de **DataTable** em pelo menos um dos formulários

## 🧪 Técnicas e Padrões Aplicados

- **MVC (Model - View - Controller)** para separação de responsabilidades
- **DAO (Data Access Object)** para manipulação das entidades no banco de dados
- **Padrão Repository** básico para encapsular lógica de persistência
- **Autenticação e controle de sessão** com múltiplos níveis de acesso
- **Data Binding** para exibição e edição de dados em `DataGridView`
- **Validações** básicas no frontend (campos obrigatórios, tipos, etc.)
- **Eventos delegados** para interação entre a View e o Controller

## 🧰 Tecnologias e Ferramentas

| Tecnologia           | Descrição                                     |
|----------------------|-----------------------------------------------|
| 🧠 C# .NET Framework  | Linguagem base do sistema                     |
| 🪟 Windows Forms      | Interface gráfica desktop                     |
| 🛢️ SQL Server         | Banco de dados relacional                     |
| 📈 System.Windows.Forms.DataVisualization | Geração de gráficos internos |
| 📤 CsvHelper          | Leitura de arquivos CSV (para povoamento)     |
| 📄 iTextSharp         | Exportação para PDF                           |

## 📂 Estrutura de Pastas

```
/Controller  -> Lógica de controle e fluxo
/DAO         -> Acesso ao banco de dados (CRUD)
/Model       -> Representação das entidades
/View        -> Formulários gráficos da aplicação
```

## 📌 Observações Finais

Este sistema é ideal para fins educacionais, proporcionando prática com conceitos essenciais de desenvolvimento desktop, banco de dados e estruturação de software escalável.
