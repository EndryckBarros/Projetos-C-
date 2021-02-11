var ViewModel = function () {
	var self = this;
	self.livros = ko.observableArray();
	self.error = ko.observable();
	self.sucess = ko.observable();
	self.delete = ko.observable();
	self.detalhe = ko.observable();
	self.codigo = ko.observable();
	self.autores = ko.observableArray();
	self.novoLivro = {
		Autor: ko.observable(),
		Genero: ko.observable(),
		Preco: ko.observable(),
		Titulo: ko.observable(),
		Ano: ko.observable()
	}
	self.novoAutor = {
		Nome: ko.observable()
	}

	var homeUri = '/Home/Edit/';
	var authorsUri = '/api/Autores/';
	var booksUri = '/api/Livros/';
	
	function ajaxHelper(uri, method, data) {
		self.sucess('');
		self.error(''); // Clear error message
		return $.ajax({
			type: method,
			url: uri,
			dataType: 'json',
			contentType: 'application/json',
			data: data ? JSON.stringify(data) : null
		}).fail(function (jqXHR, textStatus, errorThrown) {
			self.error(errorThrown);
		});
	}

	function getAllBooks() {
		ajaxHelper(booksUri, 'GET').done(function (data) {
			self.livros(data);
		});
	}

	self.getBookDetail = function (item) {
		ajaxHelper(booksUri + item.IdLivro, 'GET').done(function (data) {
			self.detalhe(data);
		});
	}

	self.getBookForPut = function (item) {
		window.location.href = homeUri + item.IdLivro;
	}

	function getAuthors() {
		ajaxHelper(authorsUri, 'GET').done(function (data) {
			self.autores(data);
		});
	}

	self.deleteBook = function (item) {
		ajaxHelper(booksUri + item.IdLivro, 'DELETE').done(function (data) {
			self.delete(data);
			getAllBooks();
			self.sucess("Livro Deletado!");
		});
	}

	self.deleteAutor = function (item) {
		ajaxHelper(authorsUri + item.IdAutor, 'DELETE').done(function (data) {
			self.delete(data);
			getAuthors();
			self.sucess("Autor Deletado!");
		});
	}

	self.addBook = function (formElement) {
		var livro = {
			IdAutor: self.novoLivro.Autor().IdAutor,
			Genero: self.novoLivro.Genero(),
			Preco: self.novoLivro.Preco(),
			Titulo: self.novoLivro.Titulo(),
			Ano: self.novoLivro.Ano()
		};

		ajaxHelper(booksUri, 'POST', livro).done(function (item) {
			self.livros.push(item);
			self.novoLivro.Genero(" ");
			self.novoLivro.Preco(" ");
			self.novoLivro.Titulo(" ");
			self.novoLivro.Ano(" ");
			self.sucess("Livro Cadastrado!");
		});
	}

	self.addAutor = function (formElement) {
		var autor = {
			Nome: self.novoAutor.Nome()
		};

		ajaxHelper(authorsUri, 'POST', autor).done(function (item) {
			self.autores.push(item);
			self.novoAutor.Nome("");
			self.sucess("Autor Cadastrado!");
		});
	}

	// Fetch the initial data.
	getAllBooks();
	getAuthors();
};

ko.applyBindings(new ViewModel());

//function Mensagem() {
//	alert('Registro gravado com sucesso!');
//}