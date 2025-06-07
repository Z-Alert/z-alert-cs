# Z-Alert API

Nossa solução foi construir uma API REST para auxiliar na localização e gestão de pessoas durante eventos extremos, como enchentes, terremotos e apagões. Essa é parte da solução para a **Global Solution 2025/1 - FIAP**.

## Objetivo
Oferecer uma API segura, escalável e documentada para ser consumida pelo aplicativo mobile (React Native).

---

## Endpoints Principais

Todos os recursos principais da API seguem um padrão RESTful. Cada um deles aceita requisições `GET`, `POST`, `PUT` e `DELETE`:

- `/api/Usuario`: gerenciamento de usuários da plataforma.
- `/api/Alerta`: gerenciamento de alertas de desaparecimento em contextos de desastres.
- `/api/Dependente`: gerenciamento dos dependentes vinculados a um usuário principal.
- `/api/Localizacoe`: gerenciamento das localizações associadas aos dependentes.
- `/api/Dispositivo`: gerenciamento de dispositivos de rastreio e monitoramento.

---

## Swagger
Disponível em:
```
GET /swagger/index.html
```

---

## Equipe
- Felipe Menezes Prometti (RM555174) - 2TDSPM
- Maria Eduarda Pires Vieira (RM558976) - 2TDSPZ
- Samuel Damasceno Silva (RM558876) - 2TDSPM

---
