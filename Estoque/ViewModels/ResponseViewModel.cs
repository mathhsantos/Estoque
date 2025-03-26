namespace Estoque.ViewModels {
    public class ResponseViewModel<T> {

        public T? Data { get; set; }
        public List<string>? Errors { get; set; } = new List<string>();

        public ResponseViewModel(T data, List<string>? errors) {
            Data = data;
            Errors = errors;
        }

        public ResponseViewModel(T data) {
            Data = data;
        }

        public ResponseViewModel(List<string> errors) {
            Errors = errors;
        }

        public ResponseViewModel(string error) {
            Errors.Add(error);
        }
    }
}
