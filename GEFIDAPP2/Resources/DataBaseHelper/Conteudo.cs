using System;

namespace GEFIDAPP2.Resources.DataBaseHelper
{
    class Conteudo
    {
        public string[] Genero()
        {
            String[] Genero = new string[]
            {
                "Selecione um genêro",
                "Masculino",
                "Feminino",
                "Outros"
            };
            return Genero;
        }

        public string[] Prioridades()
        {
            String[] Prioridades = new string[]
            {
                "Selecione uma prioridade",
                "Normal",
                "Urgente",
                "Outros"
            };
            return Prioridades;
        }

        public string[] Assuntos()
        {
            String[] Assuntos = new string[]
            {
                "Selecione um assunto",
                "Solicitação",
                "Reclamação",
                "Informação",
                "Sugestão",
                "Elogio",
                "Denuncia",
                "Comentário",
                "Outros assuntos"
            };
            return Assuntos;
        }

        public string[] StatusResposta()
        {
            String[] StatusResposta = new string[]
            {
                "1"
            };
            return StatusResposta;
        }

        public string[] Servicos()
        {
            String[] Servicos = new string[]
            {
                "000 - Selecione um serviço",
                "270 - Outros serviços",
                "404 - Análise da Iluminação Fraca da Rua",
                "277 - Análise para Concessão Benefício Taxi",
                "241 - Asfaltamento de Rua",
                "348 - Autorização para Implantação Ponto de Ônibus",
                "278 - Autorização para Taxi de Pessoa Física para Diária Nunca Mais - DNM (Abertura de Termo)",
                "279 - Autorização para Táxi Pessoa Jurídica (Abertura de Termo - Associação)",
                "280 - Autorização para Táxi Pessoa Jurídica (Abertura de Termo - Cooperativa)",
                "281 - Baixa de Cooperativa Luxo/Especial (Exclusão do Cadastro)",
                "282 - Baixa de Veículo Táxi (Exclusão do Cadastro)",
                "242 - Capina em Logradouro",
                "353 - Conservação e Manutenção de Passarela, Viaduto, Ponte e Túnel Revestido",
                "360 - Controle da Fluidez do Trânsito em Túneis e Em Seus Acessos",
                "271 - Desobstrução de Bueiros",
                "276 - Desobstrução de Bueiros na TransOeste",
                "272 - Desobstrução de Caixas e Ramais de Ralos",
                "273 - Desobstrução de Galerias de Águas Pluviais",
                "297 - Efeito Fantasma de Sinal de Trânsito",
                "326 - Emissão de Cartão de Estacionamento para Deficiente (PNE - Portadores de Necessidades Especiais)",
                "283 - Encerramento de Termo Táxi",
                "354 - Fiscalização da Manutenção de Vias Privatizadas (Pavimentação)",
                "244 - Fiscalização de Árvore Plantada Inadequadamente em Logradouro Público",
                "391 - Fiscalização de Aumento Injustificado ou Falso Desconto no Evento 'Black Friday'",
                "284 - Fiscalização de Cobrança Indevida de Táxi",
                "392 - Fiscalização de Descumprimento de Acordo Firmado em Evento de Conciliação-Procon",
                "350 - Fiscalização de Obras de Contenção em Andamento",
                "355 - Fiscalização de Obras de Urbanização em Andamento",
                "356 - Fiscalização de Obras de Urbanização em Vias Especiais",
                "357 - Fiscalização de Obras em Andamento em Áreas Especiais",
                "352 - Fiscalização de Obras em Andamento em Hospitais",
                "351 - Fiscalização de Obras em Andamento nas Escolas e EDIs (Espaço de Desenvolvimento Infantil - Creche)",
                "358 - Fiscalização de Obras em Passarela, Viaduto, Ponte e Túnel Revestido",
                "245 - Fiscalização de Plantio Recente de Árvore em Logradouro Público pela Fundação Parques e Jardins",
                "337 - Fiscalização de Poluição Atmosférica",
                "338 - Fiscalização de Poluição do Solo",
                "339 - Fiscalização de Poluição Hídrica",
                "340 - Fiscalização de Poluição Sonora",
                "393 - Fiscalização de Práticas Abusivas Contra Consumidores Cometidas por Ambulantes de Praia",
                "285 - Fiscalização de Recusa de Passageiro",
                "327 - Fiscalização dos Guardadores Credenciados no Rio Rotativo - Área Azul",
                "268 - Fiscalização em Drenagem Irregular",
                "243 - Implantação de Ecoponto",
                "328 - Implantação de Rio Rotativo - Área Laranja",
                "343 - Implantação de Sinalização Horizontal Viária",
                "344 - Implantação de Sinalização Vertical Viária",
                "248 - Implantação de Varrição",
                "329 - Implantação e Manutenção em Placas de Sinalização Rio Rotativo - Área Azul",
                "330 - Implantação e Manutenção em Placas de Sinalização Rio Rotativo - Área Laranja",
                "286 - Inclusão de Veículo Táxi",
                "287 - Ingresso / Desligamento de Cooperativa",
                "288 - Ingresso em Cooperativa Luxo/Especial",
                "359 - Inicio de Obras Públicas",
                "377 - Instalação de Abrigo de Ônibus",
                "378 - Instalação de Banheiros Públicos",
                "258 - Instalação de Caçamba da COMLURB para Atendimento em Comunidade",
                "298 - Instalação de Novos Sinais de Trânsito",
                "379 - Instalação de Relógio Digital",
                "380 - Instalação/ Remoção/ Manutenção de Totem",
                "249 - Limpeza das Marges de Rios",
                "250 - Limpeza de Ecoponto",
                "259 - Limpeza de Papeleira, Conêiner e Caçamba da COMLURB",
                "260 - Limpeza de Praça",
                "251 - Limpeza de Praias",
                "252 - Limpeza de Ralos",
                "261 - Limpeza de Resíduos após Chuva/Vento e Acidentes com Veículos",
                "253 - Limpeza de Resíduos de Obra de Órgãos Públicos e Particulares",
                "267 - Limpeza de Vala",
                "381 - Manutenção de Abrigo de Ônibus Com Publicidade",
                "382 - Manutenção de Banheiros Públicos",
                "383 - Manutenção de Relógio Digital",
                "361 - Manutenção de Sinalização em Vias Expressas",
                "341 - Manutenção de Sinalização Horizontal Viária",
                "342 - Manutenção de Sinalização Vertical Viária",
                "362 - Manutenção na Iluminação do Túnel Rebouças",
                "363 - Manutenção na Limpeza e Ventilação do Túnel Rebouças",
                "364 - Manutenção na Limpeza e Ventilação do Túnel Santa Bárbara",
                "365 - Manutenção no Túnel Mergulhão - Praça Quinze",
                "299 - Modernização de Sinal de Trânsito",
                "262 - Notificação ao Proprietário para Limpeza de Terreno Baldio",
                "269 - Obras de Reparo, Canalização ou Limpeza de Rio, Canal ou Valão",
                "345 - Operação de Trânsito",
                "349 - Operação de Trânsito na TransOeste",
                "346 - Planejamento no Tráfego",
                "376 - Poda de arvore",
                "289 - Publicidade em Táxi",
                "370 - Recapeamento / Recuperação de Pavimentação na TransOeste",
                "366 - Recapeamento/Recuperação de Pavimentação",
                "405 - Reinstalação de Ponto de Luz",
                "384 - Remoção de Abrigo de Ônibus",
                "263 - Remoção de Animais Mortos em Logradouro",
                "266 - Remoção de Carcaça de Veículo em Área Pública",
                "264 - Remoção de Resídos de Queimada em Logradouros",
                "254 - Remoção de Resíduos após Multirão de Limpeza",
                "255 - Remoção de Resíduos de Poda",
                "256 - Remoção de Resíduos no Logradouro",
                "274 - Renivelamento de Tampão/Grelha",
                "331 - Renovação do Cartão de Estacionamento para Deficiente (PNE - Portadores de Necessidades Especiais)",
                "367 - Reparo de Asfalto com Deformação ou Afundamento",
                "407 - Reparo de Aspersores (Cuca-Fresca)",
                "417 - Reparo de Aspersores (Cuca-fresca) Dando Choque",
                "408 - Reparo de Bloco de Lâmpadas Acesas Durante o Dia (Circuito Direto)",
                "434 - Reparo de Bloco de Lâmpadas Acesas Durante o Dia (Circuito Direto) na TransOeste.",
                "409 - Reparo de Bloco de Lâmpadas Apagadas (Circuito Fora)",
                "435 - Reparo de Bloco de Lâmpadas Apagadas (Circuito Fora) na TransOeste",
                "300 - Reparo de Botoeira de Sinal de Trânsito com Defeito",
                "301 - Reparo de Braço de Sinal de Trânsito Projetado ou Fora de Posição",
                "368 - Reparo de Buraco em Calçadas de Túneis e Viadutos",
                "371 - Reparo de Buraco na Calçada",
                "372 - Reparo de Buraco na Ciclovia",
                "369 - Reparo de Buraco na Pista de Túneis e Viadutos",
                "373 - Reparo de Buraco na Pista/Rua",
                "375 - Reparo de Buraco na Pista/Rua na TransOeste",
                "302 - Reparo de Cobre-Foco de Sinal de Trânsito Abalroado ou Ausente",
                "410 - Reparo de Comando ou Caixa Aérea em Poste",
                "303 - Reparo de Controlador de Sinal de Trânsito Abalroado ou Aberto",
                "304 - Reparo de Fios ou Cabos de Sinal de Trânsito Expostos",
                "305 - Reparo de Grupo de Sinal de Trânsito Apagado",
                "306 - Reparo de Grupos de Sinal de Trânsito Conflitantes",
                "307 - Reparo de Interseção de Sinal de Trânsito Apagada",
                "411 - Reparo de Lâmpada Acesa Durante o Dia",
                "436 - Reparo de Lâmpada Acesa Durante o Dia na TransOeste",
                "412 - Reparo de Lâmpada Apagada",
                "437 - Reparo de Lâmpada Apagada na TransOeste",
                "308 - Reparo de Lâmpada de Sinal de Trânsito Queimada",
                "415 - Reparo de Lâmpada Fraca",
                "438 - Reparo de Lâmpada Fraca na TransOeste",
                "414 - Reparo de Lâmpada Piscando",
                "439 - Reparo de Lâmpada Piscando na TransOeste",
                "416 - Reparo de Luminária com Cúpula ou Vidro Aberto",
                "418 - Reparo de Luminária Fora de Posição",
                "419 - Reparo de Luminária Pendurada",
                "420 - Reparo de Ponto de Luz com Ruído",
                "421 - Reparo de Poste Alto Aceso Durante o Dia",
                "422 - Reparo de Poste Alto Apagado",
                "423 - Reparo de Poste Caído ou Em Risco de Queda",
                "424 - Reparo de Poste Dando Choque",
                "425 - Reparo de Poste Danificado",
                "309 - Reparo de Poste de Sinal de Trânsito Abalroado",
                "426 - Reparo de Poste Fora de Prumo",
                "428 - Reparo de Rede",
                "427 - Reparo de Rede Partida",
                "310 - Reparo de Sinal de Trânsito Abalroado",
                "311 - Reparo de Sinal de Trânsito Aberto ou Fora de Posição",
                "312 - Reparo de Sinal de Trânsito Apagado",
                "313 - Reparo de Sinal de Trânsito com Ciclo Curto",
                "314 - Reparo de Sinal de Trânsito com Falta de Sincronismo",
                "323 - Reparo de Sinal de Trânsito com Falta de Sincronismo na TransOeste",
                "315 - Reparo de Sinal de Trânsito com Visibilidade Obstruída",
                "316 - Reparo de Sinal de Trânsito em Amarelo Piscante",
                "324 - Reparo de Sinal de Trânsito em Amarelo Piscante na TransOeste",
                "317 - Reparo de Tampão de Sinal de Trânsito Quebrado ou Ausente",
                "429 - Reparo de Tampão ou Caixa de Luz Dando Choque",
                "430 - Reparo de Transformador",
                "374 - Reparo em Asfalto Afundando",
                "431 - Reparo em Luminária Danificada",
                "318 - Reposição de Botoeira de Sinal de Trânsito Ausente",
                "275 - Reposição de Grelha/Tampão",
                "319 - Reposição de Sinal de Trânsito Ausente",
                "265 - Retirada de Caçamba da COMLURB Instalada para Atendimento em Comunidade",
                "432 - Revisão de Lâmpadas Acesas Durante o Dia",
                "433 - Revisão de Lâmpadas Apagadas",
                "320 - Revisão de Programação de Sinal de Trânsito",
                "332 - Rio Rotativo - Área Azul - Implantação",
                "333 - Rio Rotativo - Área Laranja e Azul - Cartão Morador",
                "394 - Serviço de Orientação Sobre os Direitos do Consumidor na Volta às Aulas",
                "321 - Sinal de Trânsito Acendendo Mais de Uma Cor (Em Curto)",
                "325 - Sinal de Trânsito Acendendo Mais de Uma Cor (Em Curto) na TransOeste",
                "322 - Sinal de Trânsito Travado",
                "347 - Solicitação de Contagem Volumétrica",
                "334 - Solicitação de Estacionamento de Veículos Prestadores de Serviços",
                "335 - Solicitação de Estacionamento para Deficiente (PNE - Portadores de Necessidades Especiais)",
                "336 - Solicitação de Estacionamento para Motos",
                "246 - Solicitação de Plantio de Árvore em Logradouro Público",
                "247 - Solicitação para Retirada do Protetor de Árvores em Logradouro Público",
                "290 - Transferência de Permissão",
                "291 - Troca de Veículo (Permuta) Taxi",
                "257 - Varrição de Logradouro",
                "292 - Verificação de Achados e Perdidos (Táxi)",
                "293 - Verificação de Má Conduta do Motorista de Táxi",
                "294 - Verificação de Ponto Irregular de Táxi",
                "295 - Verificação de Táxi com Irregularidades",
                "296 - Verificação do Tempo de Serviço (Certidão de Cadastro)",
                "385 - Vistoria de Abrigo de Ônibus de Concreto",
                "386 - Vistoria de Escavação Irregular (Aterro Irregular em Grande Quantidade)",
                "395 - Vistoria em Ameaça de Desabamento de Estrutura",
                "387 - Vistoria em Ameaça de Deslizamento de Barreira, Encosta, Talude",
                "388 - Vistoria em Ameaça de Rolamento de Pedra",
                "396 - Vistoria em Desabamento de Estrutura",
                "389 - Vistoria em Deslizamento de Barreira, Encosta, Talude",
                "397 - Vistoria em Imóvel Apresentando Trepidação",
                "398 - Vistoria em Imóvel com Rachadura e Infiltração",
                "399 - Vistoria em Queda de Muro de Arrimo/Contenção",
                "400 - Vistoria em Queda de Revestimento Externo",
                "401 - Vistoria em Queda de Revestimento Interno",
                "390 - Vistoria em Rolamento de Pedra",
                "402 - Vistoria Pós-Incêndio",
                "403 - Vistoria Técnica/Preventiva"
            };
            return Servicos;
        }
    }
}