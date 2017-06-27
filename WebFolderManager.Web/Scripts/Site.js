$(document).ready(function () {
	// Создали хаб.
	var searchEngineHub = $.connection.searchEngineHub;

	// Обработка запуска приложение.
	$.connection.hub.start().done(function () {
		// Запуск поиска.
		$("#button_submit_search").click(function () {
			window.stop = false;
			$('#search_result').text('');
			$('#search_result_count').text('0');
			$('#search_result_state').text('(идет поиск…)');
			searchEngineHub.server.search({
				extensions: $('#input_xml').prop("checked") ? ['.txt', '.xml'] : ['.txt'],
				onlyCurrent: $('#only_current').prop("checked") == "checked",
				path: $('#input_path_string').val(),
				query: $('#input_quiry_string').val(),
				date: $('#input_datetime').val(),
				minSize: $('#input_min_size').val(),
				maxSize: $('#input_max_size').val()
			});
		});
		// Останов поиска.
		$("#button_submit_search_stop").click(function () {
			$.connection.hub.stop();
			$.connection.hub.start();
			$('#search_result_state').text('(поиск остановлен)');
		});
	});

	// Добавление текущего результата поиска.
	searchEngineHub.client.updateSearchResults = function (count, fileName, path, size) {
		$('#search_result_count').text(count);
		$('#search_result').append('<tr>' + htmlEncode(count) + htmlEncode(fileName) + htmlEncode(path) + htmlEncode(size) + '</tr>');
	}
});

// Формат полученного значения.
function htmlEncode(value) {
	return '<td>' + value + '</td>';
}