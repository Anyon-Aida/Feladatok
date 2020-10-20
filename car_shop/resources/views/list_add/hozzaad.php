<html>
	<head>
		<meta charset="utf-8">
		<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css">
		<link rel="stylesheet" href="jquery.datetimepicker.min.css">
	</head>
	<body>
		<nav class="nav">
			<a class="navbar-brand" href="#">Kovács Zalán Dominik</a>
			<ul class="nav mx-auto">
			  <li class="nav-item">
				<a class="nav-link" href="/">Home</a>
			  </li>
			  <li class="nav-item">
				<a class="nav-link" href="#">Listázás</a>
			  </li>
			  <li class="nav-item">
				<a class="nav-link active" href="list_add/">Hozzáadás</a>
			  </li>
			</ul>
		</nav>
		<div class="container">
			<form action="{{route('/Controllers')}}" method="post">
				<div class="form-row">
					<div class="form-group col-md-6{{ $errors->has('owner.') . $x }}">
						<label for="owner-{{ $x }}" class="control-label">Tulajdonos #{{ $x }}</label>
						<input type="text" class="form-control" name="owner" id="owner-{{ $x }}" aria-describedby="emailHelp" placeholder="Név">
						@if($errors->has('owner.' . $x))
							<span class="help-block">
								{{ $errors->first('owner.' . $x)}}
							</span>
						@endif
					</div>
					<div class="form-group  col-md-4">
						<label for="inputState">Autó kiválasztása</label>
						<select id="auto" name="choose" class="form-control">
							<option selected>Choose...</option>
							<option>...</option>
						</select>
					</div>
				</div>
				<div class="form-check">
					<input type="checkbox" class="form-check-input" id="exampleCheck1">
					<label class="form-check-label" for="exampleCheck1">Garanciális</label>
				</div>
				<fieldset class="form-group">
					<div class="row">
					  <legend class="col-form-label col-sm-1 pt-0">Életkor</legend>
					  <div class="col-sm-10">
						<div class="form-check-inline">
						  <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios1" value="option1" checked>
						  <label class="form-check-label" for="gridRadios1">
							0-5
						  </label>
						</div>
						<div class="form-check-inline">
						  <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios2" value="option2">
						  <label class="form-check-label" for="gridRadios2">
							5-10
						  </label>
						</div>
						<div class="form-check-inline">
						  <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios3" value="option3">
						  <label class="form-check-label" for="gridRadios3">
							10+
						  </label>
						</div>
					  </div>
					</div>
				</fieldset>
				<div class="form-group">
					<input type="datetime-local" name="birth" id="birthdaytime" name="birthdaytime" />
				</div>
				<button type="submit" class="btn btn-primary">Submit</button>
			</form>
		</div>
	</body>
</html>