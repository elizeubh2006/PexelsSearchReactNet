# 🖼️ Pexels Image Search API – .NET 8 + Clean Architecture + Dapper

API desenvolvida em **.NET 8** que consome a **API do Pexels** para realizar pesquisas de imagens e salvar o histórico de pesquisas do usuário em um banco de dados **MySQL**.  
O projeto foi construído seguindo princípios de **Clean Architecture**, **Clean Code** e boas práticas de desenvolvimento com **Dapper**, **AutoMapper** e **Injeção de Dependência (DI)**.

---

## 🚀 Tecnologias Utilizadas

- **.NET 8 (ASP.NET Core Web API)**
- **Clean Architecture**
- **Dapper** (micro ORM)
- **AutoMapper**
- **MySQL** (rodando via Docker)
- **Docker Compose**
- **Dependency Injection**
- **Repository Pattern**
- **RESTful API**
- **Principles of Clean Code**

---

## 📂 Estrutura do Projeto

![Preview do Projeto](https://i.imgur.com/qSBOMuu.png)

---

## 🧠 Funcionalidades

✅ Pesquisar imagens na **API do Pexels**  
✅ Retornar metadados das imagens (autor, URLs, dimensões etc.)  
✅ Salvar o **histórico de pesquisas** no banco de dados  
✅ Consultar o histórico de forma **paginada**  
✅ Rodar tudo via **Docker Compose** (API + MySQL)  
✅ Código totalmente desacoplado e escalável  

---

## 🐳 Como Rodar o Projeto com Docker

1. **Clonar o repositório**
   git clone https://github.com/seu-usuario/pexels-image-search-api.git
   cd pexels-image-search-api

2. **Subir os containers**
   docker-compose up --build

3. **Acessar a API**
   - API: https://localhost:8081
   - Postman (ver imagem)
   - Banco de Dados: MySQL rodando na porta 3306

---

## ⚙️ Endpoints Principais

### 🔍 Buscar Imagens
GET /api/Photos/search?query=nature&page=1&per_page=5

### 🧾 Consultar Histórico
GET /api/SearchHistory/search?page=1&pageSize=10

---

## 🛠️ Configuração do Banco de Dados

Host: mysql  
Database: PexelsDb  
User: root  
Password: 123456  
Port: 3306

---

## 🖼️ Print do Projeto

![Preview do Projeto](https://i.imgur.com/oCBLMTm.png)

![Preview do Projeto](https://i.imgur.com/JLJwcQc.png)
---

## 🤝 Contribuição

Sinta-se à vontade para contribuir!  
Basta abrir uma **issue** ou enviar um **pull request** com melhorias.

---

## 🧑‍💻 Autor

**Seu Nome**  
📧 elizeubh2006@gmail.com  
🌐 https://linkedin.com/in/elizeubh2006

---

## 📝 Licença

Este projeto está sob a licença **MIT**.  
Consulte o arquivo LICENSE para mais detalhes.
