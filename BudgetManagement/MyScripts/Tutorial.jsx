﻿
//native HTML element names start with a lowercase letter, while custom React class names begin with an uppercase letter.
var CommentBox = React.createClass({
    render: function () {
        return (
          <div className="commentBox">
             <h1>Comments</h1>
                    <CommentList />
                    <CommentForm />
          </div>
      );
    }
});

var CommentList = React.createClass({
    render: function () {
        return (
          <div className="commentList">
                <Comment author="Daniel Lo Nigro">Hello ReactJS.NET World!</Comment>
                <Comment author="Pete Hunt">This is one comment</Comment>
                <Comment author="Jordan Walke">This is *another* comment</Comment>
          </div>
      );
    }
});

var CommentForm = React.createClass({
    render: function () {
        return (
          <div className="commentForm">
              Hello, world! I am a CommentForm.
          </div>
      );
    }
});

var Comment = React.createClass({
    render: function () {
        var md = new Remarkable();
        return (
          <div className="comment">
            <h2 className="commentAuthor">
                {this.props.author}
            </h2>
              {md.render(this.props.children.toString())}
          </div>
      );
    }
});
ReactDOM.render(
  <CommentBox />,
  document.getElementById('content')
);