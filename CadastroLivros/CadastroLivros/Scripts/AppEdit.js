var ViewModel = function () {
	var self = this;
	self.livros = ko.observableArray();
	self.autores = ko.observableArray();
	self.novoLivro = {
		Autor: ko.observable(),
		Genero: ko.observable(),
		Preco: ko.observable(),
		Titulo: ko.observable(),
		Ano: ko.observable()
	}

	var homeUri = '/Home/Edit/';
	var homeUri2 = '/Home/Index/';
	var authorsUri = '/api/Autores/';
	var booksUri = '/api/Livros/';
	
	function ajaxHelper(uri, method, data) {
		return $.ajax({
			type: method,
			url: uri,
			dataType: 'json',
			contentType: 'application/json',
			data: data ? JSON.stringify(data) : null
		}).fail(function (jqXHR, textStatus, errorThrown) {
			// let preco = $('#Preco').val();
		});
	}

	self.putBook = function (formElement) {
		debugger;
		var livro = {
			IdLivro: $('#IdLivro').val(),
			IdAutor: $('#IdAutor').val(), 
			Genero: $('#Genero').val(),
			Preco: $('#Preco').val(),
			Titulo: $('#Titulo').val(),
			Ano: $('#Ano').val()
		};

		ajaxHelper(booksUri + livro.IdLivro, 'PUT', livro).done(function (item) {
			window.location.href = homeUri2;
		});
	}
};

ko.applyBindings(new ViewModel());