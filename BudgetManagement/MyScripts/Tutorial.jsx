
//native HTML element names start with a lowercase letter, while custom React class names begin with an uppercase letter.
var CommentBox = React.createClass({
    render: function() {
        return (
          <div className="commentBox">
            Hello, world! I am a CommentBox.
          </div>
      );
    }
});
ReactDOM.render(
  <CommentBox />,
  document.getElementById('content')
);