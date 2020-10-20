<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class PostsController extends Controller
{
    public function index()
    {
        return view('list_add.hozzaad');    
    }

    public function validation(Request $request)
    {
        dd($request->owner);

        $this->validate($request, [
            'owner.*' => 'required|owner'
        ]);
    }
}
