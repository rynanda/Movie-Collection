// CAB301 - assignment 2
// An implementation of MovieCollection ADT
// 2023


using System;
using System.Runtime.InteropServices;

//A class that models a node of a binary search tree
//An instance of this class is a node in the binary search tree 
public class BTreeNode
{
	private IMovie movie; // movie
	private BTreeNode? lchild; // reference to its left child 
	private BTreeNode? rchild; // reference to its right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode? LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode? RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicate movie in this movie collection
public class MovieCollection : IMovieCollection
{
	private BTreeNode? root; // the root of the binary search tree in which movies are stored 
	private int count; // the number of movies currently stored in this movie collection 
	private IMovie[] movies; // movie collection array
	private int dvdCount; // count of DVDs to be used in NoDVDs() and in-order traversal
	private int arrayCount; // count of movies in movies array to be used in ToArray() and in-order traversal


	public int Number { get { return count; } }

	// constructor - create an empty movie collection
	public MovieCollection()
	{
		root = null;
		count = 0;	
	}

    public bool IsEmpty()
	{
		//To be completed by students
		return root == null;
	}

    public bool Insert(IMovie movie)
	{
        //To be completed by students

        // Adapted from the Week 5 tutorial.
        if ((root == null) && (Search(movie.Title) == null))
		{
			root = new BTreeNode(movie);
			count = count + 1;
			return true;
		}
		else if ((root != null) && (Search(movie.Title) == null))
		{
			Insert(movie, root);
			return true; 
		}
		return false; // Must be that movie title already exists in the collection.
    }

    private void Insert(IMovie movie, BTreeNode ptr)
	{
		if (movie.CompareTo(ptr.Movie) < 0)
		{
			if (ptr.LChild == null)
			{
				ptr.LChild = new BTreeNode(movie);
				count = count + 1;
			}
			else
				Insert(movie, ptr.LChild);
		}
		else
		{
			if (ptr.RChild == null)
			{
				ptr.RChild = new BTreeNode(movie);
				count = count + 1;
            }
			else
				Insert(movie, ptr.RChild);
		}
	}


    public bool Delete(IMovie movie)
	{
		//To be completed by students
		
		// Adapted from the Week 5 tutorial.
		// search for item and its parent
		BTreeNode? ptr = root; // search reference
		BTreeNode? parent = null; // parent of ptr
		while ((ptr != null) && (movie.CompareTo(ptr.Movie) != 0))
		{
			parent = ptr;
			if (movie.CompareTo(ptr.Movie) < 0) // move to the left child of ptr
				ptr = ptr.LChild;
			else
				ptr = ptr.RChild;
		}

		if (ptr != null) // if the search was successful
		{
			// case 3: movie has two children
			if ((ptr.LChild != null) && (ptr.RChild != null))
			{
				// find right-most node in left subtree of ptr
				if (ptr.LChild.RChild == null) // special case: right subtree of ptr.LChild is empty
				{
					ptr.Movie = ptr.LChild.Movie;
					ptr.LChild = ptr.LChild.LChild;
					count = count - 1;
					return true;
				}
				else
				{
					BTreeNode p = ptr.LChild;
					BTreeNode pp = ptr; // parent of p
					while (p.RChild != null)
					{
						pp = p;
						p = p.RChild;
					}
					// copy the movie at p to ptr
					ptr.Movie = p.Movie;
					pp.RChild = p.LChild;
					count = count - 1;
					return true;
				}
			}
			else // cases 1 & 2: item has no or only one child
			{
				BTreeNode? c;
				if (ptr.LChild != null)
				{
					c = ptr.LChild;
				}

				else
				{
					c = ptr.RChild;
				}

				// remove node ptr
				if (ptr == root) // need to change root
				{
					root = c;
					count = count - 1;
					return true;
				}

				else
				{
					if (ptr == parent.LChild)
					{
						parent.LChild = c;
						count = count - 1;
						return true;
					}

					else
					{
						parent.RChild = c;
						count = count - 1;
						return true;
					}
				}
			}
		}
		else
			return false;
	}



	public IMovie? Search(string movietitle)
	{
        //To be completed by students

        // Adapted from the Week 5 tutorial.
        return Search(movietitle, root);
	}

	private IMovie? Search(string movietitle, BTreeNode? r)
	{
		if (r != null)
		{
			if (movietitle.CompareTo(r.Movie.Title) == 0)
			{
				return r.Movie;
			}
			else if (movietitle.CompareTo(r.Movie.Title) < 0)
				return Search(movietitle, r.LChild);
			else
				return Search(movietitle, r.RChild);
		}
		else
			return null;
	}



    public int NoDVDs()
	{
        //To be completed by students

        // Adapted from the Week 5 tutorial.
        dvdCount = 0;
		return InOrderTraverseCountDVDs(root);
    }

	private int InOrderTraverseCountDVDs(BTreeNode? root)
	{
		if (root != null)
        {
            InOrderTraverseCountDVDs(root.LChild);
			dvdCount = dvdCount + root.Movie.TotalCopies;
            InOrderTraverseCountDVDs(root.RChild);
        }
		return dvdCount;
    }

    public IMovie[] ToArray()
	{
        //To be completed by students

        // Adapted from the Week 5 tutorial.
        movies = new IMovie[count];
		arrayCount = 0;
		return InOrderTraverseArray(root);
    }

	private IMovie[] InOrderTraverseArray(BTreeNode? root)
	{
		if (root != null)
		{
            InOrderTraverseArray(root.LChild);
			movies[arrayCount] = root.Movie;
			arrayCount++;
            InOrderTraverseArray(root.RChild);
        }
		return movies;
	}


    public void Clear()
	{
        //To be completed by students

        // Adapted from the Week 5 tutorial.
        root = null;
		count = 0;
    }
}





